using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankGunsController : MonoBehaviour
{
    [SerializeField] private Projectile _projectile;

    private bool _isFiring;
    private ITankAttackable _tankAttackable;

    public void Initialize(ITankAttackable tankAttackable)
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

    private void OnDestroy()
    {
        if (_tankAttackable != null)
            _tankAttackable.OnStartedFiring -= StartFiring;
    }

    private void LateUpdate()
    {
        Debug.Log(_isFiring);
        Aim();
    }

    private void Aim()
    {
        transform.right = _tankAttackable.GetAimWorldPosition() - transform.position;
    }
}
