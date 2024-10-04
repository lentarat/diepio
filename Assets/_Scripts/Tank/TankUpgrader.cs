using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankUpgrader : MonoBehaviour
{
    [SerializeField] private int _maxStatsLevel = 7;

    private Dictionary<StatsType, int> _statsToCurrentMultipliersDictionary = new()
    {
        { StatsType.Regeneration, 1 },
        { StatsType.MaxHealth, 1 },
        { StatsType.BodyDamage, 1 },
        { StatsType.BulletSpeed, 1 },
        { StatsType.BulletPenetration, 1 },
        { StatsType.BulletDamage, 1 },
        { StatsType.Reload, 1 },
        { StatsType.MovementSpeed, 1 }
    };
    public Dictionary<StatsType, int> StatsToCurrentMultipliersDictionary => _statsToCurrentLevelsDictionary;

    private Dictionary<StatsType, int> _statsToCurrentLevelsDictionary = new()
    {
        { StatsType.Regeneration, 1 },
        { StatsType.MaxHealth, 1 },
        { StatsType.BodyDamage, 1 },
        { StatsType.BulletSpeed, 1 },
        { StatsType.BulletPenetration, 1 },
        { StatsType.BulletDamage, 1 },
        { StatsType.Reload, 1 },
        { StatsType.MovementSpeed, 1 }
    };
    //public Dictionary<StatsType, int> StatsToCurrentLevelsDictionary => _statsToCurrentLevelsDictionary;

    private Dictionary<StatsType, int> _statsToMaxMultipliersDictionary = new()
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
    //public Dictionary<StatsType, int> StatsToMaxMultipliersDictionary => _statsToMaxMultipliersDictionary;

    //[SerializeField] private StatsLevels _currentStats;
    //public StatsLevels CurrentStats => _currentStats;
    //[SerializeField] private MaxStatsMultipliers _maxStatsMultipliers;
    //public MaxStatsMultipliers MaxStatsMultipliers => _maxStatsMultipliers;

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

//[Serializable]
//public struct StatsLevels
//{
//    public int RegenerationLevel;
//    public int MaxHealthLevel;
//    public int BodyDamage;
//    public int BulletSpeed;
//    public int BulletPenetration;
//    public int BulletDamage;
//    public int Reload;
//    public int MovementSpeed;
//}

//[Serializable]
//public struct MaxStatsMultipliers
//{
//    public int MaxRegenerationMultiplier;
//    public int MaxMaxHealthMultiplier;
//    public int MaxBodyDamageMultiplier;
//    public int MaxBulletSpeedMultiplier;
//    public int MaxBulletPenetrationMultiplier;
//    public int MaxBulletDamageMultiplier;
//    public int MaxReloadMultiplier;
//    public int MaxMovementSpeedMultiplier;
//}