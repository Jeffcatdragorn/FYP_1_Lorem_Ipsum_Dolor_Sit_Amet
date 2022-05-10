using UnityEngine;
using UnityEngine.InputSystem;

public class HumanoidLandInput : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; } = Vector2.zero;
    public Vector2 LookInput { get; private set; } = Vector2.zero;

    InputActions input = null;

    private void OnEnable()
    {
        input = new InputActions();
        input.HumanoidLand.Enable();

        input.HumanoidLand.Move.performed += SetMove;
        input.HumanoidLand.Move.canceled += SetMove;

        input.HumanoidLand.Look.performed += SetLook;
        input.HumanoidLand.Look.canceled += SetLook;
    }

    private void OnDisable()
    {
        input.HumanoidLand.Move.performed -= SetMove;
        input.HumanoidLand.Move.canceled -= SetMove;

        input.HumanoidLand.Look.performed -= SetLook;
        input.HumanoidLand.Look.canceled -= SetLook;
    }

    private void SetMove(InputAction.CallbackContext ctx)
    {
        MoveInput = ctx.ReadValue<Vector2>();
    }

    private void SetLook(InputAction.CallbackContext ctx)
    {
        LookInput = ctx.ReadValue<Vector2>();
    }
}
