using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonShootableTank : Tank
{
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("NonShootable tank collision. More ram damage to the enemy.");
    }
}
