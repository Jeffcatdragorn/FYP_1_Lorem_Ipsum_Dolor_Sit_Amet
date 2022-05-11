using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform cameraFollow;

    [SerializeField] HumanoidLandInput input;
    [SerializeField] CameraController cameraController;

    Rigidbody rigidbody = null;

    Vector3 playerMoveInput = Vector3.zero;

    Vector3 playerLookInput = Vector3.zero;
    Vector3 previousPlayerLookInput = Vector3.zero;
    float cameraPitch = 0.0f;
    [SerializeField] float playerLookInputLerpTime = 0.35f;

    [Header("Movement")]
    [SerializeField] float movementMultiplier = 30.0f;
    [SerializeField] float rotationSpeedMultiplier = 180.0f;
    [SerializeField] float pitchSpeedMultiplier = 180.0f;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
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
        PlayerMove();

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

    private void PlayerMove()
    {
        playerMoveInput = (new Vector3(playerMoveInput.x * movementMultiplier * rigidbody.mass, 
                                       playerMoveInput.y, 
                                       playerMoveInput.z * movementMultiplier * rigidbody.mass));
    }
}
