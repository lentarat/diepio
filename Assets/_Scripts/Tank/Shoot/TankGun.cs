using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankGun : MonoBehaviour, IGunShootable
{
    [SerializeField] private float _reloadTime;

    private float _lastShotTime;

    void IGunShootable.Shoot()
    {
        throw new System.NotImplementedException();
    }

    bool IGunShootable.IsReloadComplete()
    {
        if (_lastShotTime + _reloadTime > Time.time)
            return true;
        
        return false;
    }
}
