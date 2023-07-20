using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputActionsCatcher : MonoBehaviour
{
    //[SerializeField] private PlayerMovement _playerMovement;

    private PlayerInputActions _playerInputActions;

    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();

        //AssignInputActions();
    }
    private void OnEnable()
    {
        SetInputActionsEnabled(true);
    }

    private void OnDisable()
    {
        SetInputActionsEnabled(false);
    }

    private void SetInputActionsEnabled(bool isEnabled)
    {
        if (isEnabled)
        {
            _playerInputActions.Player.Move.Enable();
            _playerInputActions.Player.Look.Enable();
        }
        else
        {
            _playerInputActions.Player.Move.Disable();
            _playerInputActions.Player.Look.Disable();
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
}
