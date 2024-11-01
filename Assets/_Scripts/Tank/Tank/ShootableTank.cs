using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableTank : Tank
{
    [SerializeField] protected TankGunsController _tankGunsController;

    protected void Awake()
    {
        base.Initialize();
        _tankGunsController.Initialize(_tankInputActionsHolder);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Shootable Tank Trigger");
    }
}
