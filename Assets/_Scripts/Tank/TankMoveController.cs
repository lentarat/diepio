using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TankMoveController : MonoBehaviour
{
    [SerializeField] private TankUpgrader _tank;
    [SerializeField] private float _drag = 1f;
    [SerializeField] private float _speedMultipier = 1f;

    private ITankMoveable _tankMoveable;
    private Vector3 _currentVelocityVector;

    private void Awake()
    {
        _tankMoveable = new TankInputActionsHolder();
        
    }

    private void FixedUpdate()
    {
        AddVelocity();
    }

    private void AddVelocity()
    {
        Vector3 movementInputVector = _tankMoveable.GetMovementInputVector();
        Debug.Log(movementInputVector);
        if (movementInputVector == Vector3.zero)
            return;

        _currentVelocityVector += movementInputVector * _speedMultipier * Time.fixedDeltaTime;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += _currentVelocityVector;
    }
}
