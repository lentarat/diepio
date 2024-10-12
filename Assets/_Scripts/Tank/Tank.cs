using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] private TankMoveController _tankMoveController;
    [SerializeField] private TankGunsController _tankShootController;

    private TankInputActionsHolder _tankInputActionsHolder;

    private void Awake()
    {
        _tankInputActionsHolder = new();
        InitializeDependencies();
    }

    private void InitializeDependencies()
    {
        _tankMoveController.Initialize(_tankInputActionsHolder);
        _tankShootController.Initialize(_tankInputActionsHolder);
    }
}
