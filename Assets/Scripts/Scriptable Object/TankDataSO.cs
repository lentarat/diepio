using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Tank Data")]
public class TankDataSO : ScriptableObject
{
    [Header("Common")]
    public int BulletDamage;
    public int BulletPenetration;
    public int BulletSpeed;
    public int Reload;

}
