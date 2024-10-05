using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankInputActionsHolder : ITankMoveable, ITankShootable
{
    private TankInputActions _inputActions;

    public TankInputActionsHolder()
    { 
        _inputActions = new TankInputActions();
        _inputActions.Tank.MouseLeftClick.performed += HandleShootButtonClicked;
        _inputActions.Enable();
    }

    private void HandleShootButtonClicked(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("click!");
    }

    ~TankInputActionsHolder()
    {
        _inputActions.Tank.MouseLeftClick.performed -= HandleShootButtonClicked;
        _inputActions.Disable();
    }

    Vector2 ITankMoveable.GetMovementInputVector()
    {
        Vector2 movementInputVector = _inputActions.Tank.Keyboard.ReadValue<Vector2>();
        return movementInputVector;
    }

    Vector3 ITankShootable.GetAimWorldPosition()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(_inputActions.Tank.MousePosition.ReadValue<Vector2>());
        mouseWorldPosition.z = 0f;
        return mouseWorldPosition;
    }
}
