using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankInputActionsHolder : ITankMoveable
{
    private TankInputActions _inputActions;

    public TankInputActionsHolder()
    { 
        _inputActions = new TankInputActions();
        _inputActions.Enable();
    }

    ~TankInputActionsHolder()
    {
        _inputActions.Disable();
    }

    Vector2 ITankMoveable.GetMovementInputVector()
    {
        Vector2 movementInputVector = _inputActions.Tank.Keyboard.ReadValue<Vector2>();
        return movementInputVector;
    }
}
