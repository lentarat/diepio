using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShootController : MonoBehaviour
{
    private ITankShootable _tankShootable;

    public void Initialize(ITankShootable tankShootable)
    {
        _tankShootable = tankShootable;
    }

    private void LateUpdate()
    {
        Aim();
    }

    private void Aim()
    {
        transform.up = _tankShootable.GetAimWorldPosition() - transform.position;
    }
}
