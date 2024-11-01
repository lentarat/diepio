using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed; 
    [SerializeField] private float _damage;
    [SerializeField] private float _penetration;

    public void SetProperties(Vector3 startVelocity, float damageMultiplier = 1f, float penetrationMultiplier = 1f, float speedMultiplier = 1f)
    {
        _speed *= speedMultiplier;
        _damage *= damageMultiplier;
        _penetration *= penetrationMultiplier;
    }

    public void SetSpawnVelocity(Vector3 velocity)
    {
        _rigidbody.velocity = velocity;
    }
}
