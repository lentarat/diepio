using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecromancerTank : NonShootableTank
{
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Necromancer collision");
    }
}
