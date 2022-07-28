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
    public bool ShieldIsPressed { get; private set; } = false;
    public bool ShootIsPressed { get; private set; } = false;
    public bool DashIsPressed { get; private set; } = false;
    public bool OpenDoorIsPressed { get; private set; } = false;
    public bool MoveIsPressed { get; private set; } = false;
    public bool TeleportIsPressed { get; private set; } = false;
    public bool PickUpObjectIsPressed { get; private set; } = false;
    public bool EscapeIsPressed { get; private set; } = false;
    public bool GunReloadIsPressed { get; private set; } = false;
    public bool InteractIsPressed { get; private set; } = false;
    public Vector2 MousePosition { get; private set; } = Vector2.zero;
    public bool CrouchIsPressed { get; private set; } = false;
    public bool TabletIsPressed { get; private set; } = false;
    public bool InventoryIsPressed { get; private set; } = false;
    public bool FlashlightIsPressed { get; private set; } = false;
    public bool InspectIsPressed { get; private set; } = false;


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

        input.HumanoidLand.Shield.started += SetShield;
        input.HumanoidLand.Shield.canceled += SetShield;

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

        input.HumanoidLand.PauseGame.started += SetPauseGame;
        input.HumanoidLand.PauseGame.canceled += SetPauseGame;

        input.HumanoidLand.GunReload.started += SetGunReload;
        input.HumanoidLand.GunReload.canceled += SetGunReload;

        input.HumanoidLand.Interact.started += SetInteract;
        input.HumanoidLand.Interact.canceled += SetInteract;

        input.HumanoidLand.MousePosition.performed += SetMousePosition;
        input.HumanoidLand.MousePosition.canceled += SetMousePosition;

        input.HumanoidLand.Crouch.started += SetCrouch;
        input.HumanoidLand.Crouch.canceled += SetCrouch;

        input.HumanoidLand.Tablet.started += SetTablet;
        input.HumanoidLand.Tablet.canceled += SetTablet;

        input.HumanoidLand.Inventory.started += SetInventory;
        input.HumanoidLand.Inventory.canceled += SetInventory;

        input.HumanoidLand.Flashlight.started += SetFlashlight;
        input.HumanoidLand.Flashlight.canceled += SetFlashlight;

        input.HumanoidLand.MousePosition.started += SetInspect;
        input.HumanoidLand.MousePosition.canceled += SetInspect;

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

        input.HumanoidLand.Shield.started -= SetShield;
        input.HumanoidLand.Shield.canceled -= SetShield;

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

        input.HumanoidLand.PauseGame.started -= SetPauseGame;
        input.HumanoidLand.PauseGame.canceled -= SetPauseGame;

        input.HumanoidLand.GunReload.started -= SetGunReload;
        input.HumanoidLand.GunReload.canceled -= SetGunReload;

        input.HumanoidLand.Interact.started -= SetInteract;
        input.HumanoidLand.Interact.canceled -= SetInteract;

        input.HumanoidLand.MousePosition.performed -= SetMousePosition;
        input.HumanoidLand.MousePosition.canceled -= SetMousePosition;

        input.HumanoidLand.Crouch.started -= SetCrouch;
        input.HumanoidLand.Crouch.canceled -= SetCrouch;

        input.HumanoidLand.Tablet.started -= SetTablet;
        input.HumanoidLand.Tablet.canceled -= SetTablet;

        input.HumanoidLand.Inventory.started -= SetInventory;
        input.HumanoidLand.Inventory.canceled -= SetInventory;

        input.HumanoidLand.Flashlight.started -= SetFlashlight;
        input.HumanoidLand.Flashlight.canceled -= SetFlashlight;

        input.HumanoidLand.MousePosition.started -= SetInspect;
        input.HumanoidLand.MousePosition.canceled -= SetInspect;

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

    private void SetShield(InputAction.CallbackContext ctx)
    {
        ShieldIsPressed = ctx.started;
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

    private void SetPauseGame(InputAction.CallbackContext ctx)
    {
        EscapeIsPressed = ctx.started;
    }

    private void SetGunReload(InputAction.CallbackContext ctx)
    {
        GunReloadIsPressed = ctx.started;
    }

    private void SetInteract(InputAction.CallbackContext ctx)
    {
        InteractIsPressed = ctx.started;
    }

    private void SetMousePosition(InputAction.CallbackContext ctx)
    {
        MousePosition = ctx.ReadValue<Vector2>();
    }

    private void SetCrouch(InputAction.CallbackContext ctx)
    {
        CrouchIsPressed = ctx.started;
    }

    private void SetTablet(InputAction.CallbackContext ctx)
    {
        TabletIsPressed = ctx.started;
    }

    private void SetInventory(InputAction.CallbackContext ctx)
    {
        InventoryIsPressed = ctx.started;
    }

    private void SetFlashlight(InputAction.CallbackContext ctx)
    {
        FlashlightIsPressed = ctx.started;
    }

    private void SetInspect(InputAction.CallbackContext ctx)
    {
        FlashlightIsPressed = ctx.started;
    }

    //private void SetZoomCamera(InputAction.CallbackContext ctx)
    //{
    //    ZoomCameraInput = ctx.ReadValue<float>();
    //}
}
