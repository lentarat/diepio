using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Input Actions")]
    [SerializeField] private PlayerInputActionsCatcher _playerInputActionsCatcher;

    [Header("Movement")]
    [SerializeField] private float _acceleration;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _dragForce;
    [SerializeField] private float _minSqrMovementVelocity;

    private Vector2 _moveInputVector;
    private Vector2 _movementVelocityVector;

    private void Update()
    {
        if (IsMoveButtonPressed())
        {
            AddAccelerationToVelocity();
            ClampMaxVelocity();
        }

        if (IsMoveVelocityMoreThanThreshold())
        {
            DragForceEffectOnVelocity();
            Move();
        }
        else
        {
            SetMovementVelocityZero();
        }
        
    }

    private bool IsMoveButtonPressed()
    {
        _moveInputVector = _playerInputActionsCatcher.GetMoveInput();
        if (_moveInputVector == Vector2.zero)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void AddAccelerationToVelocity()
    {
        _movementVelocityVector += _moveInputVector * _acceleration * Time.deltaTime;
    }

    private void ClampMaxVelocity() 
    {
        _movementVelocityVector = Vector2.ClampMagnitude(_movementVelocityVector, _maxSpeed);
    }

    private bool IsMoveVelocityMoreThanThreshold()
    {
        return _movementVelocityVector.sqrMagnitude > _minSqrMovementVelocity;
    }

    private void DragForceEffectOnVelocity()
    {
        _movementVelocityVector += -_movementVelocityVector.normalized * _dragForce * Time.deltaTime;
    }

    private void Move()
    {
        transform.position += new Vector3(_movementVelocityVector.x, _movementVelocityVector.y, 0f) * Time.deltaTime;
    }

    private void SetMovementVelocityZero()
    {
        if (_movementVelocityVector.sqrMagnitude != 0f)
        {
            _movementVelocityVector = Vector2.zero;
        }
    }
}
