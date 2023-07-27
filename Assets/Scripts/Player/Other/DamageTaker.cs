using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaker : MonoBehaviour, IDamageable
{
    public event System.Action OnDamageTaken;

    public void GetDamage()
    {
        Debug.Log("gets");
    }
}
