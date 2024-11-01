using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankGunsController : MonoBehaviour
{
    private bool _isFiring;
    private ITankAttackable _tankAttackable;
    private IGunShootable[] _guns;

    public void Initialize(ITankAttackable tankAttackable)
    {
        SetupShooting(tankAttackable);
        GetGunsInChildren();
    }

    private void SetupShooting(ITankAttackable tankAttackable)
    {
        _tankAttackable = tankAttackable;

        if (_tankAttackable != null)
        {
            _tankAttackable.OnStartedFiring += StartFiring;
            _tankAttackable.OnFinishedFiring += FinishFiring;
        }
    }

    private void StartFiring()
    {
        _isFiring = true;
    }

    private void FinishFiring()
    {
        _isFiring = false;
    }

    private void GetGunsInChildren()
    {
        _guns = gameObject.GetComponentsInChildren<IGunShootable>();
        Debug.Log($"Guns count: {_guns.Length}");
    }

    private void OnDestroy()
    {
        if (_tankAttackable != null)
            _tankAttackable.OnStartedFiring -= StartFiring;
    }

    private void Aim()
    {
        transform.right = _tankAttackable.GetAimWorldPosition() - transform.position;
    }

    private void Update()
    {
        Aim();
        
        if(_isFiring)
            ShootEachGun();
    }

    private void ShootEachGun()
    {
        foreach (IGunShootable gun in _guns)
        {
            if (gun.IsReloadComplete())
            {
                gun.Shoot();
            }
        }
    }
}
