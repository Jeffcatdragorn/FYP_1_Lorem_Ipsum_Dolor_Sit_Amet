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
    [SerializeField] float gravity = 0.0f;

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
        playerMoveInput.y = PlayerGravity();
        playerMoveInput = PlayerRun();
        playerMoveInput = PlayerMove();

        rigidbody.AddRelativeForce(playerMoveInput, ForceMode.Force);
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

    private float PlayerGravity()
    {
        if (playerIsGrounded)
        {
            gravity = 0.0f;
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
                gravity = gravityFallCurrent;
            }
        }
        return gravity;
    }

    private Vector3 PlayerRun()
    {
        Vector3 calculatedPlayerRunSpeed = playerMoveInput;
        if (input.RunIsPressed)
        {
            calculatedPlayerRunSpeed.x *= runMultiplier;
            calculatedPlayerRunSpeed.z *= runMultiplier;
        }
        return calculatedPlayerRunSpeed;
    }

    private Vector3 PlayerMove()
    {
        Vector3 calculatedPlayerMOvement = (new Vector3(playerMoveInput.x * movementMultiplier * rigidbody.mass, 
                                       playerMoveInput.y * rigidbody.mass, 
                                       playerMoveInput.z * movementMultiplier * rigidbody.mass));

        return calculatedPlayerMOvement;
    }
}
