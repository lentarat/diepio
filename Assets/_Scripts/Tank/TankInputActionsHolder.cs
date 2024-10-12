using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankInputActionsHolder : ITankMoveable, ITankAttackable
{
    private event Action OnShootButtonDown;
    private event Action OnShootButtonUp;
    private TankInputActions _inputActions;

    public TankInputActionsHolder()
    { 
        _inputActions = new TankInputActions();
        _inputActions.Tank.MouseLeftClick.performed += HandleShootButtonDown;
        _inputActions.Tank.MouseLeftClick.canceled += HandleShootButtonUp;
        _inputActions.Enable();
    }

    private void HandleShootButtonDown(InputAction.CallbackContext obj)
    {
        OnShootButtonDown?.Invoke();
    }

    private void HandleShootButtonUp(InputAction.CallbackContext obj)
    {
        OnShootButtonUp?.Invoke();
    }

    ~TankInputActionsHolder()
    {
        _inputActions.Tank.MouseLeftClick.performed -= HandleShootButtonDown;
        _inputActions.Tank.MouseLeftClick.canceled -= HandleShootButtonUp;
        _inputActions.Disable();
    }

    Vector2 ITankMoveable.GetMovementInputVector()
    {
        Vector2 movementInputVector = _inputActions.Tank.Keyboard.ReadValue<Vector2>();
        return movementInputVector;
    }

    event Action ITankAttackable.OnStartedFiring
    {
        add
        {
            OnShootButtonDown += value;
        }

        remove
        {
            OnShootButtonDown -= value;
        }
    }
    
    event Action ITankAttackable.OnFinishedFiring
    {
        add
        {
            OnShootButtonUp += value;
        }

        remove
        {
            OnShootButtonUp -= value;
        }
    }

    Vector3 ITankAttackable.GetAimWorldPosition()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(_inputActions.Tank.MousePosition.ReadValue<Vector2>());
        mouseWorldPosition.z = 0f;
        return mouseWorldPosition;
    }
}
