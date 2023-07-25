using UnityEngine;
using Unity.Netcode;

public class PlayerMouseLook : NetworkBehaviour
{
    [Header("Input Actions")]
    [SerializeField] private PlayerInputActionsCatcher _playerInputActionsCatcher;

    [Header("Look")]
    [SerializeField] private float _sensitivity;

    private Vector3 _mousePosition;

    public override void OnNetworkSpawn()
    {
        if (!IsOwner)
        {
            enabled = false;
        }
    }

    private void Update()
    {
        Look();
    }

    private void Look()
    {
        _mousePosition = _playerInputActionsCatcher.GetMousePosition();
        Vector3 lookDirection = GetLookDirection();
        RotatePlayer(lookDirection);
    }

    private Vector3 GetLookDirection()
    {
        Vector3 screenSpacePlayerPosition = Camera.main.WorldToScreenPoint(transform.position);

        Vector3 lookDirection = _mousePosition - screenSpacePlayerPosition;
        lookDirection = lookDirection.normalized;

        return lookDirection;
    }

    private void RotatePlayer(Vector3 toDirection)
    {
        var angle = Vector3.SignedAngle(Vector3.down, toDirection, Vector3.forward) + 180f;
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }
}
