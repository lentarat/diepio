using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankUpgrader : MonoBehaviour
{
    [SerializeField] private Dictionary<StatsType, int> _statsLevelsDictionary = new();
    public Dictionary<StatsType, int> StatsLevelsDictionary => _statsLevelsDictionary;

    [SerializeField] private Dictionary<StatsType, int> _maxStatsMultipliersDictionary = new()
    {
        { StatsType.Regeneration, 5 },
        { StatsType.MaxHealth, 5 },
        { StatsType.BodyDamage, 5 },
        { StatsType.BulletSpeed, 5 },
        { StatsType.BulletPenetration, 5 },
        { StatsType.BulletDamage, 5 },
        { StatsType.Reload, 5 },
        { StatsType.MovementSpeed, 5 }
    };
    public Dictionary<StatsType, int> MaxStatsMultipliersDictionary => _maxStatsMultipliersDictionary;



    [SerializeField] private StatsLevels _currentStats;
    public StatsLevels CurrentStats => _currentStats;
    [SerializeField] private MaxStatsMultipliers _maxStatsMultipliers;
    public MaxStatsMultipliers MaxStatsMultipliers => _maxStatsMultipliers;

    public enum StatsType
    { 
        Regeneration,
        MaxHealth,
        BodyDamage,
        BulletSpeed,
        BulletPenetration,
        BulletDamage,
        Reload,
        MovementSpeed
    }

    public void UpgradeStatsLevel(StatsType statsType)
    {
        
    }
}

[Serializable]
public struct StatsLevels
{
    public int RegenerationLevel;
    public int MaxHealthLevel;
    public int BodyDamage;
    public int BulletSpeed;
    public int BulletPenetration;
    public int BulletDamage;
    public int Reload;
    public int MovementSpeed;
}

[Serializable]
public struct MaxStatsMultipliers
{
    public int MaxRegenerationMultiplier;
    public int MaxMaxHealthMultiplier;
    public int MaxBodyDamageMultiplier;
    public int MaxBulletSpeedMultiplier;
    public int MaxBulletPenetrationMultiplier;
    public int MaxBulletDamageMultiplier;
    public int MaxReloadMultiplier;
    public int MaxMovementSpeedMultiplier;
}