using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TankMoveController : MonoBehaviour
{
    [SerializeField] private TankUpgrader _tankUpgrader;
    [SerializeField] private float _drag = 1f;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _speedMultipier = 1f;

    private Vector3 _currentVelocityVector;
    private ITankMoveable _tankMoveable;

    public void Initialize(ITankMoveable tankMoveable)
    {
        _tankMoveable = tankMoveable;
    }

    private void FixedUpdate()
    {
        AddVelocity();
        ClampSpeed();
    }

    private void AddVelocity()
    {
        Vector3 movementInputVector = _tankMoveable.GetMovementInputVector();
        if (movementInputVector == Vector3.zero)
            return;

        Vector3 velocityToAdd = movementInputVector * _speedMultipier * _tankUpgrader.StatsToCurrentMultipliersDictionary[TankUpgrader.StatsType.MovementSpeed] * Time.fixedDeltaTime;
        _currentVelocityVector += velocityToAdd;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += _currentVelocityVector;
    }

    private void ClampSpeed()
    {
        if (_currentVelocityVector.magnitude > 0f)
        {
            var value = Mathf.Lerp(_currentVelocityVector.magnitude, 0f, _drag * Time.fixedDeltaTime);
            _currentVelocityVector = _currentVelocityVector.normalized * value;
        }
    }
}
