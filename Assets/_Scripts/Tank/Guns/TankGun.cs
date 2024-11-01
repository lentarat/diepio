using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankGun : MonoBehaviour, IGunShootable
{
    [SerializeField] private Projectile _projectile;
    [SerializeField] private float _reloadTime;
    [SerializeField] private float _projectileEjectionForce;
    
    private float _lastShotTime;

    void IGunShootable.Shoot()
    {
        EjectProjectile();
        _lastShotTime = Time.time;
    }

    bool IGunShootable.IsReloadComplete()
    {
        if (_lastShotTime + _reloadTime < Time.time)
            return true;
        
        return false;
    }

    private void EjectProjectile()
    { 
        Projectile projectile = Instantiate(_projectile);
        projectile.transform.position = transform.position;
        projectile.SetSpawnVelocity(transform.right * _projectileEjectionForce);
    }
}
