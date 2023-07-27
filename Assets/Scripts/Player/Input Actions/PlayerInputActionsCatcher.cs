using UnityEngine;
using Unity.Netcode;
using UnityEngine.InputSystem;

public class PlayerInputActionsCatcher : NetworkBehaviour
{
    public event System.Action<bool> OnFireButtonStarted;

    private PlayerInputActions _playerInputActions;

    public override void OnNetworkSpawn()
    {
        if (!IsOwner)
        {
            enabled = false;
        }
    }

    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();

        AssignInputActions();
    }
    private void OnEnable()
    {
        SetInputActionsEnabled(true);
    }

    private void OnDisable()
    {
        SetInputActionsEnabled(false);
    }

    private void AssignInputActions()
    {
        _playerInputActions.Player.Fire.started += DoFire;
        _playerInputActions.Player.Fire.canceled += DoFire;
    }

    private void SetInputActionsEnabled(bool isEnabled)
    {
        if (isEnabled)
        {
            _playerInputActions.Player.Move.Enable();
            _playerInputActions.Player.Look.Enable();
            _playerInputActions.Player.Fire.Enable();
        }
        else
        {
            _playerInputActions.Player.Move.Disable();
            _playerInputActions.Player.Look.Disable();
            _playerInputActions.Player.Fire.Disable();
        }
    }

    public Vector2 GetMoveInput()
    {
        return _playerInputActions.Player.Move.ReadValue<Vector2>();
    }

    public Vector2 GetMousePosition()
    {
        return _playerInputActions.Player.Look.ReadValue<Vector2>();
    }

    private void DoFire(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            OnFireButtonStarted?.Invoke(true);
        }
        else
        {
            OnFireButtonStarted?.Invoke(false);
        }
    }
}
