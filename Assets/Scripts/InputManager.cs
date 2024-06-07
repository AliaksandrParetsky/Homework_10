using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerControls playerControls;
    private PlayerControls.PlayerActions playerActions;

    public Vector2 Input { get; private set; }

    private void Awake()
    {
        playerControls = new PlayerControls();
        playerActions = playerControls.Player;
    }

    private void OnEnable()
    {
        playerControls.Enable();

        playerActions.Movement.started += ctx => OnStartMove(ctx);
        playerActions.Movement.performed += ctx => OnPerformedMove(ctx);
        playerActions.Movement.canceled += ctx => OnCanceledMove(ctx);
    }

    private void OnDisable()
    {
        playerControls.Disable();

        playerActions.Movement.started -= ctx => OnStartMove(ctx);
        playerActions.Movement.performed -= ctx => OnPerformedMove(ctx);
        playerActions.Movement.canceled -= ctx => OnCanceledMove(ctx);
    }

    private void OnStartMove(InputAction.CallbackContext context)
    {
        Input = context.ReadValue<Vector2>();
    }

    private void OnPerformedMove(InputAction.CallbackContext context)
    {
        Input = context.ReadValue<Vector2>();
    }

    private void OnCanceledMove(InputAction.CallbackContext context)
    {
        Input = context.ReadValue<Vector2>();
    }
}
