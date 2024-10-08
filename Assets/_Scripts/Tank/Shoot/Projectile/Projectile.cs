using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{ 
    private Vector3 _currentVelocityVector;

    public void Initialize(Vector3 direction)
    { 
        
    }

    protected virtual void Move()
    {
        transform.position += _currentVelocityVector;
    }

    private void Update()
    {
        Move();
    }
}
