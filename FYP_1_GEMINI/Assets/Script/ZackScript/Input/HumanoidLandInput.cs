using UnityEngine;
using UnityEngine.InputSystem;

public class HumanoidLandInput : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; } = Vector2.zero;
    public Vector2 LookInput { get; private set; } = Vector2.zero;
    public bool InvertMouseY { get; private set; } = true;
    public bool ChangeCameraWasPressedThisFrame { get; private set; } = false;
    public float ZoomCameraInput { get; private set; } = 0.0f;
    public bool InvertScroll { get; private set; } = true;
    public bool RunIsPressed { get; private set; } = false;
    public bool JumpIsPressed { get; private set; } = false;
    public bool GrappleIsPressed { get; private set; } = false;
    public bool ShootIsPressed { get; private set; } = false;
    public bool DashIsPressed { get; private set; } = false;
    public bool OpenDoorIsPressed { get; private set; } = false;
    public bool MoveIsPressed { get; private set; } = false;
    public bool TeleportIsPressed { get; private set; } = false;
    public bool PickUpObjectIsPressed { get; private set; } = false;

    InputActions input = null;


    private void OnEnable()
    {
        input = new InputActions();
        input.HumanoidLand.Enable();

        input.HumanoidLand.Move.performed += SetMove;
        input.HumanoidLand.Move.canceled += SetMove;

        input.HumanoidLand.Look.performed += SetLook;
        input.HumanoidLand.Look.canceled += SetLook;

        input.HumanoidLand.Run.started += SetRun;
        input.HumanoidLand.Run.canceled += SetRun;

        input.HumanoidLand.Jump.started += SetJump;
        input.HumanoidLand.Jump.canceled += SetJump;

        input.HumanoidLand.GrapplingHook.started += SetGrapplingHook;
        input.HumanoidLand.GrapplingHook.canceled += SetGrapplingHook;

        input.HumanoidLand.Shoot.started += SetShoot;
        input.HumanoidLand.Shoot.canceled += SetShoot;

        input.HumanoidLand.Dash.started += SetDash;
        input.HumanoidLand.Dash.canceled += SetDash;

        input.HumanoidLand.OpenDoor.started += SetOpenDoor;
        input.HumanoidLand.OpenDoor.canceled += SetOpenDoor;
        
        input.HumanoidLand.Teleport.started += SetTeleport;
        input.HumanoidLand.Teleport.canceled += SetTeleport;

        input.HumanoidLand.PickUpObject.started += SetPickUpObject;
        input.HumanoidLand.PickUpObject.canceled += SetPickUpObject;

        //input.HumanoidLand.ZoomCamera.started += SetZoomCamera;
        //input.HumanoidLand.ZoomCamera.canceled += SetZoomCamera;
    }

    private void OnDisable()
    {
        input.HumanoidLand.Move.performed -= SetMove;
        input.HumanoidLand.Move.canceled -= SetMove;

        input.HumanoidLand.Look.performed -= SetLook;
        input.HumanoidLand.Look.canceled -= SetLook;

        input.HumanoidLand.Run.started -= SetRun;
        input.HumanoidLand.Run.canceled -= SetRun;
        
        input.HumanoidLand.Jump.started -= SetJump;
        input.HumanoidLand.Jump.canceled -= SetJump;

        input.HumanoidLand.GrapplingHook.started -= SetGrapplingHook;
        input.HumanoidLand.GrapplingHook.canceled -= SetGrapplingHook;

        input.HumanoidLand.Shoot.started -= SetShoot;
        input.HumanoidLand.Shoot.canceled -= SetShoot;

        input.HumanoidLand.Dash.started -= SetDash;
        input.HumanoidLand.Dash.canceled -= SetDash;

        input.HumanoidLand.OpenDoor.started -= SetOpenDoor;
        input.HumanoidLand.OpenDoor.canceled -= SetOpenDoor;

        input.HumanoidLand.Teleport.started -= SetTeleport;
        input.HumanoidLand.Teleport.canceled -= SetTeleport;

        input.HumanoidLand.PickUpObject.started -= SetPickUpObject;
        input.HumanoidLand.PickUpObject.canceled -= SetPickUpObject;

        //input.HumanoidLand.ZoomCamera.started -= SetZoomCamera;
        //input.HumanoidLand.ZoomCamera.canceled -= SetZoomCamera;

        input.HumanoidLand.Disable();
    }

    private void Update()
    {
        ChangeCameraWasPressedThisFrame = input.HumanoidLand.ChangeCamera.WasPressedThisFrame();
    }

    private void SetMove(InputAction.CallbackContext ctx)
    {
        MoveInput = ctx.ReadValue<Vector2>();
        MoveIsPressed = !(MoveInput == Vector2.zero);
    }

    private void SetLook(InputAction.CallbackContext ctx)
    {
        LookInput = ctx.ReadValue<Vector2>();
    }

    private void SetRun(InputAction.CallbackContext ctx)
    {
        RunIsPressed = ctx.started;
    }

    private void SetJump(InputAction.CallbackContext ctx)
    {
        JumpIsPressed = ctx.started;
    }

    private void SetGrapplingHook(InputAction.CallbackContext ctx)
    {
        GrappleIsPressed = ctx.started;
    } 
    
    private void SetShoot(InputAction.CallbackContext ctx)
    {
        ShootIsPressed = ctx.started;
    }

    private void SetDash(InputAction.CallbackContext ctx)
    {
        DashIsPressed = ctx.started;
    }

    private void SetOpenDoor(InputAction.CallbackContext ctx)
    {
        OpenDoorIsPressed = ctx.started;
    }

    private void SetTeleport(InputAction.CallbackContext ctx)
    {
        TeleportIsPressed = ctx.started;
    }
    private void SetPickUpObject(InputAction.CallbackContext ctx)
    {
        PickUpObjectIsPressed = ctx.started;
    }


    //private void SetZoomCamera(InputAction.CallbackContext ctx)
    //{
    //    ZoomCameraInput = ctx.ReadValue<float>();
    //}
}
