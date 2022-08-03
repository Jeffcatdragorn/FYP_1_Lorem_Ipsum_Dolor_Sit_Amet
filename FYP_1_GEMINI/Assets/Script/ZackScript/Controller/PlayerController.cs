using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public static Transform cameraFollow;

    [SerializeField] HumanoidLandInput input;
    [SerializeField] CameraController cameraController;

    new Rigidbody rigidbody = null;
    CapsuleCollider capsuleCollider = null;

    Vector3 playerMoveInput = Vector3.zero;

    Vector3 playerLookInput = Vector3.zero;
    Vector3 previousPlayerLookInput = Vector3.zero;
    float cameraPitch = 0.0f;
    [SerializeField] float playerLookInputLerpTime = 0.35f;

    public enum State
    {
        Detective, Fighter,
    }

    public static State state;

    [SerializeField] Animator animator;

    [Header("Movement")]
    [SerializeField] float movementMultiplier = 30.0f;
    [SerializeField] float notGroundedMovementMultiplier = 1.25f;
    [SerializeField] float rotationSpeedMultiplier = 180.0f;
    [SerializeField] float pitchSpeedMultiplier = 180.0f;
    [SerializeField] float runMultiplier = 2.5f;

    [Header("Health / Sanity")]
    [SerializeField] int maxhealth = 100;
    [SerializeField] Slider statusBar;
    [SerializeField] int tickRate = 1;
    [SerializeField] int tickTime = 1;

    [Header("GroundChecker")]
    [SerializeField] bool playerIsGrounded = true;
    [SerializeField][Range(0.0f, 1.8f)] float groundCheckRadiusMultiplier = 0.9f;
    [SerializeField][Range(-0.95f, 1.05f)] float groundCheckerExtraDistance = 0.05f;
    [SerializeField] LayerMask groundLayer;
    RaycastHit groundCheckHit = new RaycastHit();

    [Header("Gravity")]
    [SerializeField] float gravityFallCurrent = -100.0f;
    [SerializeField] float gravityFallMin = -100.0f;
    [SerializeField] float gravityFallMax = -500.0f;
    [SerializeField][Range(-5.0f, -35.0f)] float gravityFallIncrementAmount = -20.0f;
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

    //[Header("Grappling")]
    //[SerializeField] bool playerIsGrappling = false;
    //[SerializeField] Transform debugGrapplePoint;
    //[SerializeField] float grappleSpeed = 5.0f;
    //[SerializeField] LineRenderer lineRenderer;
    //[SerializeField] GameObject pullSlider;
    //private Vector3 grapplePoint;
    //private Vector3 triggerPoint;
    //public LayerMask grappleObjects;
    //public LayerMask triggerObjects;
    //private float maxGrappleDistance = 100f;
    //private bool grappleCastOnce = false;
    //public DetectiveSolution detectiveController;
    //private bool triggerCheck;


    [Header("Shooting")]
    [SerializeField] Transform cam;
    [SerializeField] Transform player;
    [SerializeField] Transform gunTip;
    [SerializeField] float shootRange = 100f;
    [SerializeField] LayerMask shootLayer;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float shootCooldown = 0.1f;
    [SerializeField] float shootCooldownCounter = 0.0f;
    [SerializeField] float shootChargingCounter = 0.0f;
    [SerializeField] bool isUsingShotgun = true;
    [SerializeField] int bulletsPerShot = 6;
    [SerializeField] GameObject impactEffect;
    [SerializeField] float inaccuracyDistance = 5.0f;
    public ParticleSystem muzzleFlash;
    public float bulletSpeed;
    public GameObjectController objectController;
    public GameObject gunModel;

    [Header("GunReload")]
    [SerializeField] int maxBullets = 6;
    [SerializeField] int currentBulletCount = 6;
    public float GunReloadCooldown;
    [SerializeField] float GunReloadCooldownCounter = 0.0f;
    [SerializeField] TextMeshProUGUI BulletCountText;

    [Header("Dashing")]
    [SerializeField] float initialDashForce = 750.0f;
    [SerializeField] float continualDashForceMultiplier = 0.1f;
    [SerializeField] float dashTime = 0.175f;
    [SerializeField] float dashTimeCounter = 0.0f;
    [SerializeField] float coyotedashTime = 0.15f;
    [SerializeField] float coyotedashTimeCounter = 0.0f;
    [SerializeField] float dashBufferTime = 0.2f;
    [SerializeField] float dashBufferTimeCounter = 0.0f;
    [SerializeField] bool playerIsDashing = false;
    [SerializeField] bool dashWasPressedLastFrame = false;
    [SerializeField] float dashCooldown = 1.0f;
    [SerializeField] float dashCooldownCounter = 0.0f;
    public Animator charAnimation;

    [Header("Teleporting")]
    [SerializeField] float teleportDistance = 0.5f;
    [SerializeField] float teleportCooldown = 1.0f;
    [SerializeField] float teleportCooldownCounter = 0.0f;
    [SerializeField] LayerMask teleportStopLayer;

    [Header("Shield")]
    [SerializeField] GameObject shieldObject;

    [Header("Crouch")]
    //[SerializeField] float crouchColliderSize;
    [SerializeField] CapsuleCollider playerCollider;
    [SerializeField] GameObject firstPersonCameraFollow;
    [SerializeField] Transform normalCamera;
    [SerializeField] Transform crouchCamera;
    [SerializeField] float crouchSpeed = 0.0f;
    public static bool forceCrouch = false;

    [Header("Flashlight")]
    [SerializeField] GameObject flashlight;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rigidbody = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    private void FixedUpdate()
    {
        BulletCountText.text = currentBulletCount.ToString();

        if (!cameraController.usingOrbitalCamera)
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

        PlayerCrouch();

        switch (state)
        {
            default:
            case State.Detective:
                playerMoveInput = PlayerDash();
                PlayerShoot();
                PlayerGunReload();
                gunModel.SetActive(true);
                PlayerFlashlight();
                break;

            case State.Fighter:
                gunModel.SetActive(false); ;
                flashlight.SetActive(false);
                ParasiteTeleport();
                ParasiteRunning();
                ParasiteAttack();
                ParasiteShield();
                HealthTickDown();
                break;
        }

        playerMoveInput *= rigidbody.mass;

        rigidbody.AddRelativeForce(playerMoveInput, ForceMode.Force);
    }

    //private void Update()
    //{
    //    Debug.Log("X : " + playerMoveInput.x);
    //    Debug.Log("Y : " + playerMoveInput.y);
    //    Debug.Log("Z : " + playerMoveInput.z);
    //}

    //private void LateUpdate()
    //{
    //    DrawLine();
    //}

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
        return Physics.SphereCast(rigidbody.position, sphereCastRadius, Vector3.down, out groundCheckHit, sphereCastTravelDistance, groundLayer);
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
            if (groundSlopeAngle == 0.0f)
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

                if (groundSlopeAngle < maxSlopeAngle)
                {
                    if (input.MoveIsPressed)
                    {
                        calculatedPlayerMovement.y += groundedGravity;
                    }
                }
                else
                {
                    float calculatedSlopeGravity = groundSlopeAngle * 0.2f;
                    if (calculatedSlopeGravity < calculatedPlayerMovement.y)
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
            if (playerFallTimer < 0.0f)
            {
                if (gravityFallCurrent > gravityFallMax) //negative values
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

        else if (input.JumpIsPressed && playerIsJumping && !playerIsGrounded && jumpTimeCounter > 0.0f)
        {
            calculatedJumpInput = initialJumpForce * continualJumpForceMultiplier;
        }

        else if (playerIsJumping && playerIsGrounded)
        {
            playerIsJumping = false;
        }

        return calculatedJumpInput;
    }

    //private Vector3 PlayerGrapple()
    //{
    //    Vector3 calculatedGrappleInput = playerMoveInput;

    //    if (input.GrappleIsPressed)
    //    {
    //        if (Physics.Raycast(origin: cam.position, direction: cam.forward, out RaycastHit rayHit, maxGrappleDistance, grappleObjects) && grappleCastOnce == false)
    //        {
    //            Debug.Log("Grappling");
    //            playerIsGrappling = true;
    //            grapplePoint = rayHit.point;
    //            debugGrapplePoint.position = rayHit.point;
    //            //if (rayHit.transform.tag == "triggerGrapple")
    //            //{
    //            //    janjanController.grappleCheck = true;
    //            //    return calculatedGrappleInput = playerMoveInput;
    //            //}
    //            grappleCastOnce = true;
    //        }

    //        else if (Physics.Raycast(origin: cam.position, direction: cam.forward, out RaycastHit triggerHit, maxGrappleDistance, triggerObjects) && grappleCastOnce == false)
    //        {
    //            lineRenderer.positionCount = 2;
    //            playerIsGrappling = true;
    //            triggerCheck = true;
    //            triggerPoint = triggerHit.point;
    //            debugGrapplePoint.position = triggerHit.point;
    //            //pullSlider.SetActive(true);
    //            grappleCastOnce = true;
    //        }

    //        else if (playerIsGrappling == false)
    //        {
    //            if (detectiveController != null)
    //                detectiveController.OpenDoorWithShooting(false);
    //            grapplePoint = Vector3.zero;
    //            return calculatedGrappleInput = playerMoveInput;
    //        }

    //        if (grapplePoint != Vector3.zero)
    //        {
    //            lineRenderer.positionCount = 2;
    //            calculatedGrappleInput = (grapplePoint - transform.position).normalized * grappleSpeed;
    //        }

    //        if (triggerCheck == true)
    //        {
    //            Debug.Log("Triggering");
    //            if (detectiveController != null)
    //                detectiveController.OpenDoorWithShooting(true);
    //        }
    //    }

    //    else
    //    {
    //        if (detectiveController != null)
    //            detectiveController.OpenDoorWithShooting(false);
    //        playerIsGrappling = false;
    //        triggerCheck = false;
    //        lineRenderer.positionCount = 0;
    //        //spullSlider.SetActive(false);
    //        grappleCastOnce = false;
    //    }

    //    return calculatedGrappleInput;
    //}

    private void PlayerShoot()
    {
        SetShootCooldownCounter();

        if (input.ShootIsPressed == true)
        {
            SetShootChargeIncrease();
            if (shootChargingCounter > 1.0f)
            {
                if (shootCooldownCounter == 0.0f && currentBulletCount != 0)
                {
                    muzzleFlash.Play();
                    AudioManager.instance.PlaySound("revolverShoot", cameraFollow.position, true);
                    currentBulletCount -= 1;

                    if (Physics.Raycast(origin: cam.position, direction: cam.forward, out RaycastHit hit, shootRange, enemyLayer, QueryTriggerInteraction.Ignore))
                    {

                        Enemies_Manager enemy = hit.transform.GetComponent<Enemies_Manager>();
                        if (enemy != null)
                        {
                            enemy.TakeDamage(1);
                        }
                    }

                    if (Physics.Raycast(origin: cam.position, direction: cam.forward, out RaycastHit hit2, shootRange, shootLayer))
                    {
                        Instantiate(impactEffect, hit2.point, Quaternion.LookRotation(hit.normal));
                        if (objectController != null)
                            objectController.changeForms(hit2.transform.name);
                    }

                    shootCooldownCounter = shootCooldown;
                }
            }
        }

        else SetShootChargeDecrease();
    }

    private void PlayerGunReload()
    {
        SetGunReloadCooldownCounter();

        if (input.GunReloadIsPressed && currentBulletCount < 6 && GunReloadCooldownCounter == 0.0f)
        {
            AudioManager.instance.PlaySound("revolverReload", cameraFollow.position, true);
            currentBulletCount++;
            GunReloadCooldownCounter = GunReloadCooldown;
        }
    }

    private Vector3 PlayerDash()
    {
        //float startTime = Time.time;
        //float dashTime = startTime + dashDuration;
        //Debug.LogWarning(dashTime);
        //while (Time.time < dashTime)
        //{
        //    new Vector3(0, 0, input.LookInput.x + dashSpeed;
        //    charAnimation.SetTrigger("Dash");
        //    yield return null;
        //}
        //MeleeCombat.windowActive = true;

        Vector3 calculatedDashInput = playerMoveInput;

        SetDashTimeCounter();
        SetCoyoteDashTimeCounter();
        SetDashBufferCounter();
        SetDashCooldownCounter();

        if (dashBufferTimeCounter > 0.0f && !playerIsDashing && coyotedashTimeCounter > 0.0f && dashCooldownCounter == 0.0f)
        {
            if (Vector3.Angle(rigidbody.transform.up, groundCheckHit.normal) < maxSlopeAngle)
            {
                calculatedDashInput = new Vector3(playerMoveInput.x * initialDashForce,
                                                   playerMoveInput.y,
                                                   playerMoveInput.z * initialDashForce);
                playerIsDashing = true;
                dashBufferTimeCounter = 0.0f;
                coyotedashTimeCounter = 0.0f;
                //charAnimation.SetTrigger("Dash");
                MeleeCombat.windowActive = true;
                dashCooldownCounter = dashCooldown;
            }
        }

        else if (input.DashIsPressed && playerIsDashing && !playerIsGrounded && dashTimeCounter > 0.0f)
        {
            calculatedDashInput = new Vector3(playerMoveInput.x * initialDashForce * continualDashForceMultiplier,
                                                   playerMoveInput.y,
                                                   playerMoveInput.z * initialDashForce * continualDashForceMultiplier);
        }

        else if (playerIsDashing && playerIsGrounded)
        {
            playerIsDashing = false;
        }

        return calculatedDashInput;
    }

    private void PlayerCrouch()
    {
        if(input.CrouchIsPressed == true || forceCrouch == true)
        {
            playerCollider.height = 1;

            firstPersonCameraFollow.transform.position = crouchCamera.position;

            //if (Vector3.Distance(firstPersonCameraFollow.transform.position, crouchCamera.position) > 0.1f)
            //{
            //    Vector3 moveDirection = (crouchCamera.position - firstPersonCameraFollow.transform.position);
            //    firstPersonCameraFollow.GetComponent<Rigidbody>().isKinematic = false;
            //    firstPersonCameraFollow.GetComponent<Rigidbody>().AddForce(moveDirection * crouchSpeed);
            //    // Vector3.Lerp(heldObject.transform.position, holdBigParent.transform.position, moveSpeed);
            //}
        }

        else
        {
            playerCollider.height = 2;

            firstPersonCameraFollow.transform.position = normalCamera.position;

            //if (Vector3.Distance(firstPersonCameraFollow.transform.position, normalCamera.position) > 0.1f)
            //{
            //    Vector3 moveDirection = (normalCamera.position - firstPersonCameraFollow.transform.position);
            //    firstPersonCameraFollow.GetComponent<Rigidbody>().AddForce(moveDirection * crouchSpeed);
            //    // Vector3.Lerp(heldObject.transform.position, holdBigParent.transform.position, moveSpeed);
            //}
        }
    }

    private void PlayerFlashlight()
    {
        if(input.FlashlightIsPressed == true)
        {
            flashlight.SetActive(true);
        }

        else
        {
            flashlight.SetActive(false);
        }
    }

    private void ParasiteTeleport()
    {
        SetTeleportCooldownCounter();

        if (input.TeleportIsPressed && teleportCooldownCounter == 0.0f)
        {
            if (Physics.Raycast(transform.position, rigidbody.transform.TransformDirection(playerMoveInput), out RaycastHit teleportRay, teleportDistance, teleportStopLayer))
            {
                Vector3 teleportPoint = player.position + rigidbody.transform.TransformDirection(playerMoveInput) * teleportDistance;
                transform.position = teleportPoint;
                teleportCooldownCounter = teleportCooldown;
            }
            else
            {
                Vector3 teleportPoint = player.position + rigidbody.transform.TransformDirection(playerMoveInput) * teleportDistance;
                transform.position = teleportPoint;
                teleportCooldownCounter = teleportCooldown;
            }
            Debug.DrawRay(transform.position, rigidbody.transform.TransformDirection(playerMoveInput), Color.red, teleportDistance);
        }
    }

    private void ParasiteShield()
    {
        if (input.ShieldIsPressed)
            shieldObject.SetActive(true);
        else
            shieldObject.SetActive(false);
    }

    private void ParasiteRunning()
    {
        if (playerMoveInput != new Vector3(0,0,0))
        {
            animator.SetBool("Walking", true);
        }

        else
            animator.SetBool("Walking", false);
    }

    private void ParasiteAttack()
    {
        if(input.ShootIsPressed)
        {
            animator.SetTrigger("Attack");
        }
    }

    private void HealthTickDown()
    {
        if(Time.time % tickTime == 0)
            statusBar.value -= tickRate;
    }

    public void HealthIncrease(int amount)
    {
        if (statusBar.value < 100)
        {
            statusBar.value += amount;
        }
    }

    public void HealthDecrease(int amount)
    {
        if (statusBar.value > 0)
        {
            statusBar.value -= amount;
        }
    }

    //void DrawLine()
    //{
    //    if (!playerIsGrappling) return;

    //    if (playerIsGrappling)
    //    {
    //        lineRenderer.SetPosition(index: 0, grappleTip.position);
    //        lineRenderer.SetPosition(index: 1, grapplePoint);
    //    }

    //    if (triggerCheck)
    //    {
    //        lineRenderer.SetPosition(index: 0, grappleTip.position);
    //        lineRenderer.SetPosition(index: 1, triggerPoint);
    //    }
    //}

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
        if (playerIsJumping && !playerIsGrounded)
        {
            jumpTimeCounter -= Time.fixedDeltaTime;
        }
        else
        {
            jumpTimeCounter = jumpTime;
        }
    }
    private void SetDashBufferCounter()
    {
        if (!dashWasPressedLastFrame && input.DashIsPressed)
        {
            dashBufferTimeCounter = dashBufferTime;
        }
        else if (dashBufferTimeCounter > 0.0f)
        {
            dashBufferTimeCounter -= Time.fixedDeltaTime;
        }
        dashWasPressedLastFrame = input.DashIsPressed;
    }
    private void SetCoyoteDashTimeCounter()
    {
        if (playerIsGrounded)
        {
            coyotedashTimeCounter = coyotedashTime;
        }
        else
        {
            coyotedashTimeCounter -= Time.fixedDeltaTime;
        }
    }
    private void SetDashTimeCounter()
    {
        if (playerIsDashing && !playerIsGrounded)
        {
            dashTimeCounter -= Time.fixedDeltaTime;
        }
        else
        {
            dashTimeCounter = dashTime;
        }
    }
    private void SetDashCooldownCounter()
    {
        if (dashCooldownCounter > 0)
        {
            dashCooldownCounter -= Time.deltaTime;
        }

        if (dashCooldownCounter <= 0)
        {
            dashCooldownCounter = 0.0f;
        }
    }
    private void SetShootCooldownCounter()
    {
        if (shootCooldownCounter > 0)
        {
            shootCooldownCounter -= Time.deltaTime;
        }

        if (shootCooldownCounter <= 0)
        {
            shootCooldownCounter = 0.0f;
        }
    }

    private void SetShootChargeIncrease()
    {
        if(shootChargingCounter < 5.0f)
        {
            if(Time.time % 1 == 0)
            {
                Debug.Log("Yea");
                shootChargingCounter += 1.0f;
            }
        }

        if(shootChargingCounter > 5.0f)
        {
            shootChargingCounter = 5.0f;
        }
    }

    private void SetShootChargeDecrease()
    {
        if (shootChargingCounter > 0.0f)
        {
            if (Time.time % 1 == 0)
            {
                Debug.Log("Yea1");
                shootChargingCounter -= 1.0f;
            }
        }

        if (shootChargingCounter < 0.0f)
        {
            shootChargingCounter = 0.0f;
        }
    }

    private void SetGunReloadCooldownCounter()
    {
        if (GunReloadCooldownCounter > 0)
        {
            GunReloadCooldownCounter -= Time.deltaTime;
        }

        if (GunReloadCooldownCounter <= 0)
        {
            GunReloadCooldownCounter = 0.0f;
        }
    }

    Vector3 GetShootingDirection()
    {
        Vector3 targetPos = cam.position + cam.forward * shootRange;
        targetPos = new Vector3(targetPos.x + Random.Range(-inaccuracyDistance, inaccuracyDistance),
            targetPos.y + Random.Range(-inaccuracyDistance, inaccuracyDistance),
            targetPos.z + Random.Range(-inaccuracyDistance, inaccuracyDistance));

        Vector3 direction = targetPos - cam.position;
        return direction.normalized;
    }
    private void SetTeleportCooldownCounter()
    {
        if (teleportCooldownCounter > 0)
        {
            teleportCooldownCounter -= Time.deltaTime;
        }

        if (teleportCooldownCounter <= 0)
        {
            teleportCooldownCounter = 0.0f;
        }
    }
}