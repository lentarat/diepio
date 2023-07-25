using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableTank : Tank
{
    [Header("Catch Fire Click")]
    [SerializeField] private PlayerInputActionsCatcher _playerInputActionsCatcher;
    
    [Header("Tank Specific Stats")]
    [SerializeField] private TankData _tankData;

    [Header("Player Stats")]
    [SerializeField] private PlayerStats _playerStats;

    [Header("Projectile Prefab")]
    [SerializeField] private GameObject _projectile;

    private void Awake()
    {
        _playerInputActionsCatcher.OnFireButtonStarted += Fire;
    }

    private void Fire()
    {
        SpawnProjectile();
    }

    private void SpawnProjectile()
    {
        Debug.Log("Fire");
        
    }
}
