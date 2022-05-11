using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public bool usingOrbitalCamera { get; private set; } = false;

    [SerializeField] HumanoidLandInput input;

    CinemachineVirtualCamera activeCamera;
    int activeCameraPriorityModifier = 31337;

    public Camera mainCamera;
    public CinemachineVirtualCamera cinemachineFirstPerson;
    public CinemachineVirtualCamera cinemachineThirdPerson;
    public CinemachineVirtualCamera cinemachineOrbit;

    private void Start()
    {
        ChangeCamera(); //first time
    }

    private void Update()
    {
        if (input.changeCameraWasPressedThisFrame)
        {
            ChangeCamera();
        }
    }

    private void ChangeCamera()
    {
        if(cinemachineThirdPerson == activeCamera)
        {
            SetCameraPriorities(cinemachineThirdPerson, cinemachineFirstPerson);
            usingOrbitalCamera = false;
            mainCamera.cullingMask &= ~(1 << LayerMask.NameToLayer("playerSelf"));
        }

        else if (cinemachineFirstPerson == activeCamera)
        {
            SetCameraPriorities(cinemachineFirstPerson, cinemachineOrbit);
            usingOrbitalCamera = true;
            mainCamera.cullingMask |= 1 << LayerMask.NameToLayer("playerSelf");
        }

        else if (cinemachineOrbit == activeCamera)
        {
            SetCameraPriorities(cinemachineOrbit, cinemachineThirdPerson);
            activeCamera = cinemachineThirdPerson;
            usingOrbitalCamera = false;
        }

        else //for first time or if error
        {
            cinemachineThirdPerson.Priority += activeCameraPriorityModifier;
            activeCamera = cinemachineThirdPerson;
        }
    }

    private void SetCameraPriorities(CinemachineVirtualCamera currentCameraMode, CinemachineVirtualCamera newCameraMode)
    {
        currentCameraMode.Priority -= activeCameraPriorityModifier;
        newCameraMode.Priority += activeCameraPriorityModifier;
        activeCamera = newCameraMode;
    }
}
