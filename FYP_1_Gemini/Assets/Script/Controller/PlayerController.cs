using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform cameraFollow;

    [SerializeField] HumanoidLandInput input;
    [SerializeField] CameraController cameraController;

    new Rigidbody rigidbody = null;
    CapsuleCollider capsuleCollider = null;

    Vector3 playerMoveInput = Vector3.zero;

    Vector3 playerLookInput = Vector3.zero;
    Vector3 previousPlayerLookInput = Vector3.zero;
    float cameraPitch = 0.0f;
    [SerializeField] float playerLookInputLerpTime = 0.35f;

    [Header("Movement")]
    [SerializeField] float movementMultiplier = 30.0f;
    [SerializeField] float notGroundedMovementMultiplier = 1.25f;
    [SerializeField] float rotationSpeedMultiplier = 180.0f;
    [SerializeField] float pitchSpeedMultiplier = 180.0f;
    [SerializeField] float runMultiplier = 2.5f;

    [Header("GroundChecker")]
    [SerializeField] bool playerIsGrounded = true;
    [SerializeField][Range(0.0f, 1.8f)] float groundCheckRadiusMultiplier = 0.9f;
    [SerializeField][Range(-0.95f, 1.05f)] float groundCheckerExtraDistance = 0.05f;
    RaycastHit groundCheckHit = new RaycastHit();

    [Header("Gravity")]
    [SerializeField] float gravityFallCurrent = -100.0f;
    [SerializeField] float gravityFallMin = -100.0f;
    [SerializeField] float gravityFallMax = -500.0f;
    [SerializeField] [Range(-5.0f, -35.0f)] float gravityFallIncrementAmount= -20.0f;
    [SerializeField] float gravityFallIncrementTime = 0.05f;
    [SerializeField] float playerFallTimer = 0.0f;
    [SerializeField] float groundedGravity = -1.0f;
    [SerializeField] float maxSlopeAngle = 47.5f;

    [Header("Jumping")]
    [SerializeField] float initialJumpForce = 750.0f;
    [SerializeField] float continualJumpForceMultiplier = 0.1f;
    [SerializeField] float jumpTime = 0.175f;
    [SerializeField] float jumpTimeCounter = 0.0f;
    [SerializeField] float coyoteTime = 0.15f;
    [SerializeField] float coyoteTimeCounter = 0.0f;
    [SerializeField] float jumpBufferTime = 0.2f;
    [SerializeField] float jumpBufferTimeCounter = 0.0f;
    [SerializeField] bool playerIsJumping = false;
    [SerializeField] bool jumpWasPressedLastFrame = false;

    [Header("Grappling")]
    [SerializeField] bool playerIsGrappling = false;
    [SerializeField] Transform debugGrapplePoint;
    [SerializeField] float grappleSpeed = 5.0f;
    [SerializeField] LineRenderer lineRenderer;
    private Vector3 grapplePoint;
    public LayerMask grappleObjects;
    public Transform grappleTip, cam, player;
    private float maxGrappleDistance = 100f;
    private bool grappleCastOnce = false;

    [Header("Shooting")]
    [SerializeField] Transform gunTip;
    [SerializeField] float shootRange = 100f;
    [SerializeField] LayerMask shootObjects;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    private void FixedUpdate()
    {
        if(!cameraController.usingOrbitalCamera)
        {
            playerLookInput = GetLookInput();
            PlayerLook();
            PitchCamera();
        }

        playerMoveInput = GetMoveInput();
        playerIsGrounded = PlayerGroundCheck();

        playerMoveInput = PlayerMove();
        playerMoveInput = PlayerSlope();
        playerMoveInput = PlayerRun();
        
        playerMoveInput.y = PlayerFallGravity();
        playerMoveInput.y = PlayerJump();

        playerMoveInput = PlayerGrapple();

        playerMoveInput *= rigidbody.mass;

        rigidbody.AddRelativeForce(playerMoveInput, ForceMode.Force);
    }

    private void Update()
    {
        
    }

    private void LateUpdate()
    {
        DrawLine();
    }

    private Vector3 GetLookInput()
    {
        previousPlayerLookInput = playerLookInput;
        playerLookInput = new Vector3(input.LookInput.x, (input.InvertMouseY ? -input.LookInput.y : input.LookInput.y), 0.0f);
        return Vector3.Lerp(previousPlayerLookInput, playerLookInput * Time.deltaTime, playerLookInputLerpTime);
    }

    private void PlayerLook()
    {
        rigidbody.rotation = Quaternion.Euler(0.0f, rigidbody.rotation.eulerAngles.y + (playerLookInput.x * rotationSpeedMultiplier), 0.0f);
    }

    private void PitchCamera()
    {
        //Vector3 rotationValues = cameraFollow.rotation.eulerAngles;
        cameraPitch += playerLookInput.y * pitchSpeedMultiplier;
        cameraPitch = Mathf.Clamp(cameraPitch, -89.9f, 89.9f);

        cameraFollow.rotation = Quaternion.Euler(cameraPitch, cameraFollow.rotation.eulerAngles.y, cameraFollow.rotation.eulerAngles.z);
    }

    private Vector3 GetMoveInput()
    {
        return new Vector3(input.MoveInput.x, 0.0f, input.MoveInput.y);
    }

    private bool PlayerGroundCheck()
    {
        float sphereCastRadius = capsuleCollider.radius * groundCheckRadiusMultiplier;
        float sphereCastTravelDistance = capsuleCollider.bounds.extents.y - sphereCastRadius + groundCheckerExtraDistance;
        return Physics.SphereCast(rigidbody.position, sphereCastRadius, Vector3.down, out groundCheckHit, sphereCastTravelDistance);
    }

    private Vector3 PlayerMove()
    {
        return ((playerIsGrounded) ? (playerMoveInput * movementMultiplier) : (playerMoveInput * movementMultiplier * notGroundedMovementMultiplier));
    }

    private Vector3 PlayerRun()
    {
        Vector3 calculatedPlayerRunSpeed = playerMoveInput;
        if (input.MoveIsPressed && input.RunIsPressed)
        {
            calculatedPlayerRunSpeed *= runMultiplier;
        }
        return calculatedPlayerRunSpeed;
    }

    private Vector3 PlayerSlope()
    {
        Vector3 calculatedPlayerMovement = playerMoveInput;

        if (playerIsGrounded)
        {
            Vector3 localGroundCheckHitNormal = rigidbody.transform.InverseTransformDirection(groundCheckHit.normal);

            float groundSlopeAngle = Vector3.Angle(localGroundCheckHitNormal, rigidbody.transform.up);
            if(groundSlopeAngle == 0.0f)
            {
                if (input.MoveIsPressed)
                {
                    RaycastHit rayHit;
                    float rayHeightFromGround = 0.1f;
                    float rayCalculatedHeight = rigidbody.position.y - capsuleCollider.bounds.extents.y + rayHeightFromGround;
                    Vector3 rayOrigin = new Vector3(rigidbody.position.x, rayCalculatedHeight, rigidbody.position.z);
                    if (Physics.Raycast(rayOrigin, rigidbody.transform.TransformDirection(calculatedPlayerMovement), out rayHit, 0.75f))
                    {
                        if (Vector3.Angle(rayHit.normal, rigidbody.transform.up) > maxSlopeAngle)
                        {
                            calculatedPlayerMovement.y = -movementMultiplier;
                        }
                    }
                    Debug.DrawRay(rayOrigin, rigidbody.transform.TransformDirection(calculatedPlayerMovement), Color.green, 1.0f);
                }
                if (calculatedPlayerMovement.y == 0.0f)
                {
                    calculatedPlayerMovement.y = groundedGravity;
                }
            }

            else
            {
                Quaternion slopeAngleRotation = Quaternion.FromToRotation(rigidbody.transform.up, localGroundCheckHitNormal);
                calculatedPlayerMovement = slopeAngleRotation * calculatedPlayerMovement;

                float relativeSlopeAngle = Vector3.Angle(calculatedPlayerMovement, rigidbody.transform.up) - 90.0f;
                calculatedPlayerMovement += calculatedPlayerMovement * (relativeSlopeAngle / 90.0f);

                if(groundSlopeAngle < maxSlopeAngle)
                {
                    if (input.MoveIsPressed)
                    {
                        calculatedPlayerMovement.y += groundedGravity;
                    }
                }
                else
                {
                    float calculatedSlopeGravity = groundSlopeAngle * 0.2f;
                    if(calculatedSlopeGravity < calculatedPlayerMovement.y)
                    {
                        calculatedPlayerMovement.y = calculatedSlopeGravity;
                    }
                }
            }
#if UNITY_EDITOR
            Debug.DrawRay(rigidbody.position, rigidbody.transform.TransformDirection(calculatedPlayerMovement), Color.red, 0.5f);
#endif
        }

        return calculatedPlayerMovement;
    }

    private float PlayerFallGravity()
    {
        float gravity = playerMoveInput.y;
        if (playerIsGrounded)
        {
            gravityFallCurrent = gravityFallMin;
        }

        else
        {
            playerFallTimer -= Time.fixedDeltaTime;
            if(playerFallTimer < 0.0f)
            {
                if(gravityFallCurrent > gravityFallMax) //negative values
                {
                    gravityFallCurrent += gravityFallIncrementAmount;
                }
                playerFallTimer = gravityFallIncrementTime;
            }
            gravity = gravityFallCurrent;
        }
        return gravity;
    }

    private float PlayerJump()
    {
        float calculatedJumpInput = playerMoveInput.y;

        SetJumpTimeCounter();
        SetCoyoteTimeCounter();
        SetJumpBufferCounter();

        if (jumpBufferTimeCounter > 0.0f && !playerIsJumping && coyoteTimeCounter > 0.0f)
        {
            if (Vector3.Angle(rigidbody.transform.up, groundCheckHit.normal) < maxSlopeAngle)
            {
                calculatedJumpInput = initialJumpForce;
                playerIsJumping = true;
                jumpBufferTimeCounter = 0.0f;
                coyoteTimeCounter = 0.0f;
            }
        }

        else if(input.JumpIsPressed && playerIsJumping && !playerIsGrounded && jumpTimeCounter > 0.0f)
        {
            calculatedJumpInput = initialJumpForce * continualJumpForceMultiplier;
        }

        else if(playerIsJumping && playerIsGrounded)
        {
            playerIsJumping = false;
        }

        return calculatedJumpInput;
    }

    private Vector3 PlayerGrapple()
    {
        Vector3 calculatedGrappleInput = playerMoveInput;

        if (input.GrappleIsPressed)
        {
            if (Physics.Raycast(origin: cam.position, direction: cam.forward, out RaycastHit rayHit, maxGrappleDistance, grappleObjects) && grappleCastOnce == false)
            {
                playerIsGrappling = true;
                grapplePoint = rayHit.point;
                debugGrapplePoint.position = rayHit.point;
                grappleCastOnce = true;
            }

            else if(playerIsGrappling == false)
            {
                return calculatedGrappleInput = playerMoveInput;
            }

            lineRenderer.positionCount = 2;
            calculatedGrappleInput = (grapplePoint - transform.position).normalized * grappleSpeed;
        }

        else
        {
            playerIsGrappling = false;
            lineRenderer.positionCount = 0;
            grappleCastOnce = false;
        }

        return calculatedGrappleInput;
    }

    private void PlayerShoot()
    {
        if(input.ShootIsPressed == true)
        {
            if (Physics.Raycast(origin: cam.position, direction: cam.forward, out RaycastHit hit, shootRange))
            {

            }
        }
    }

    void DrawLine()
    {
        if (!playerIsGrappling) return;
        lineRenderer.SetPosition(index: 0, grappleTip.position);
        lineRenderer.SetPosition(index: 1, grapplePoint);
    }

    private void SetJumpBufferCounter()
    {
        if (!jumpWasPressedLastFrame && input.JumpIsPressed)
        {
            jumpBufferTimeCounter = jumpBufferTime;
        }
        else if (jumpBufferTimeCounter > 0.0f)
        {
            jumpBufferTimeCounter -= Time.fixedDeltaTime;
        }
        jumpWasPressedLastFrame = input.JumpIsPressed;
    }

    private void SetCoyoteTimeCounter()
    {
        if (playerIsGrounded)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.fixedDeltaTime;
        }
    }

    private void SetJumpTimeCounter()
    {
        if(playerIsJumping && !playerIsGrounded)
        {
            jumpTimeCounter -= Time.fixedDeltaTime;
        }
        else
        {
            jumpTimeCounter = jumpTime;
        }
    }
}
