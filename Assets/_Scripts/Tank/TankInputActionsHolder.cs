using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankInputActionsHolder : ITankMoveable, ITankShootable
{
    private event Action OnShotFired;
    private TankInputActions _inputActions;

    public TankInputActionsHolder()
    { 
        _inputActions = new TankInputActions();
        _inputActions.Tank.MouseLeftClick.performed += HandleShootButtonClicked;
        _inputActions.Enable();
    }
    
    ~TankInputActionsHolder()
    {
        _inputActions.Tank.MouseLeftClick.performed -= HandleShootButtonClicked;
        _inputActions.Disable();
    }

    private void HandleShootButtonClicked(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnShotFired?.Invoke();
    }

    Vector2 ITankMoveable.GetMovementInputVector()
    {
        Vector2 movementInputVector = _inputActions.Tank.Keyboard.ReadValue<Vector2>();
        return movementInputVector;
    }

    event Action ITankShootable.OnShotFired
    {
        add
        {
            OnShotFired += value;
        }

        remove
        {
            OnShotFired -= value;
        }
    }
    
    Vector3 ITankShootable.GetAimWorldPosition()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(_inputActions.Tank.MousePosition.ReadValue<Vector2>());
        mouseWorldPosition.z = 0f;
        return mouseWorldPosition;
    }
}
