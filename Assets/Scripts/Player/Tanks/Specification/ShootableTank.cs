using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableTank : Tank
{
    [Header("Catch Fire Click")]
    [SerializeField] private PlayerInputActionsCatcher _playerInputActionsCatcher;
    
    [Header("Stats")]
    [SerializeField] private TankDataSO _tankDataSO;
    [SerializeField] private PlayerStats _playerStats;

    [Header("Projectile")]
    [SerializeField] private GameObject _projectile;
    [SerializeField] private Transform _projectileSpawnTransform;

    [Header("Essentials")]
    [SerializeField] private DamageTaker _damageTaker;

    [SerializeField] private float _health;

    private bool _isFireButtonPressed;
    private float _timeWhenShot;

    private void Awake()
    {
        _playerInputActionsCatcher.OnFireButtonStarted += Fire;

        _damageTaker.OnDamageTaken += HandleDamageTaken;
    }

    private void Update()
    {
        if (_isFireButtonPressed && HasTimeSinceLastShotElapsed())
        {
            _timeWhenShot = Time.time;
            SpawnProjectile();
        }
    }

    private bool HasTimeSinceLastShotElapsed()
    {
        if (Time.time > _timeWhenShot + _playerStats.Reload * _tankDataSO.Reload )
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Fire(bool fireButtonPressed)
    {
        _isFireButtonPressed = fireButtonPressed;
    }

    private void SpawnProjectile()
    {
        GameObject spawnedProjectile = Instantiate(_projectile, _projectileSpawnTransform.position, transform.rotation);
        spawnedProjectile.SetActive(true);
    }

    private void HandleDamageTaken()
    {
        _health -=
    }
}
