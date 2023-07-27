using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardFlyingProjectile : MonoBehaviour
{
    private float _lifeTime = 5f;

    private float _minVelocity = 3f;
    private float _velocityDecreaseSmoothness = 0.5f;
    private float _velocity;

    private float _spawnTime;

    private void Start()
    {
        _spawnTime = Time.time;

        DecreaseVelocity();
    }

    private void Update()
    {
        FlyForward();

        DecreaseVelocity();

        if (HasLifeTimeElapsed())
        {
            Destroy(gameObject);
        }
    }

    private void FlyForward()
    {
        transform.Translate(Vector3.up * _velocity * Time.deltaTime);
    }

    private bool HasLifeTimeElapsed()
    {
        if (Time.time > _spawnTime + _lifeTime)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void DecreaseVelocity()
    {
        _velocity = GetInverseExponentialVelocity(Time.time - _spawnTime);
    }

    private float GetInverseExponentialVelocity(float time)
    {
        return Mathf.Exp(-time * _velocityDecreaseSmoothness) + _minVelocity;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<IDamageable>()?.GetDamage();
    }
}
