using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class TankShootController : MonoBehaviour
{
    [SerializeField] private Projectile _projectile;

    private ITankShootable _tankShootable;

    public void Initialize(ITankShootable tankShootable)
    {
        _tankShootable = tankShootable;
        
        if(_tankShootable != null ) 
            _tankShootable.OnShotFired += Shoot;
    }

    private void Shoot()
    {
        Debug.Log("SHHHOOOOT");
        Projectile projectile = Instantiate(_projectile);
        
    }

    private void OnDestroy()
    {
        if (_tankShootable != null)
            _tankShootable.OnShotFired -= Shoot;
    }

    private void LateUpdate()
    {
        Aim();
    }

    private void Aim()
    {
        transform.right = _tankShootable.GetAimWorldPosition() - transform.position;
    }
}
