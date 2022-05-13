using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public bool usingOrbitalCamera { get; private set; } = false;

    [SerializeField] HumanoidLandInput input;

    [SerializeField] float cameraZoomModifier = 32.0f;

    float minCameraZoomDistance = 2.0f;
    float minOrbitCameraZoomDistance = 2.0f;
    float maxCameraZoomDistance = 12.0f;
    float maxOrbitCameraZoomDistance = 36.0f;

    CinemachineVirtualCamera activeCamera;
    int activeCameraPriorityModifier = 31337;

    public Camera mainCamera;
    public CinemachineVirtualCamera cinemachineFirstPerson;
    public CinemachineVirtualCamera cinemachineThirdPerson;
    CinemachineFramingTransposer cinemachineFramingTransposerThirdPerson;
    public CinemachineVirtualCamera cinemachineOrbit;
    CinemachineFramingTransposer cinemachineFramingTransposerOrbit;

    private void Awake()
    {
        cinemachineFramingTransposerThirdPerson = cinemachineThirdPerson.GetCinemachineComponent<CinemachineFramingTransposer>();
        cinemachineFramingTransposerOrbit = cinemachineOrbit.GetCinemachineComponent<CinemachineFramingTransposer>();
    }

    private void Start()
    {
        ChangeCamera(); //first time
    }

    private void Update()
    {
        if(!(input.ZoomCameraInput == 0.0f))
        {
            ZoomCamera();
        }

        if (input.ChangeCameraWasPressedThisFrame)
        {
            ChangeCamera();
        }
    }

    private void ZoomCamera()
    {
        if(activeCamera == cinemachineThirdPerson)
        {
            cinemachineFramingTransposerThirdPerson.m_CameraDistance = Mathf.Clamp(cinemachineFramingTransposerThirdPerson.m_CameraDistance + 
                                                                       (input.InvertScroll ? input.ZoomCameraInput : -input.ZoomCameraInput) / cameraZoomModifier, 
                                                                       minCameraZoomDistance,
                                                                       maxCameraZoomDistance);
        }

        if (activeCamera == cinemachineOrbit)
        { 
            cinemachineFramingTransposerOrbit.m_CameraDistance = Mathf.Clamp(cinemachineFramingTransposerOrbit.m_CameraDistance + 
                                                                 (input.InvertScroll ? input.ZoomCameraInput : -input.ZoomCameraInput) / cameraZoomModifier,
                                                                 minOrbitCameraZoomDistance,
                                                                 maxOrbitCameraZoomDistance);
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