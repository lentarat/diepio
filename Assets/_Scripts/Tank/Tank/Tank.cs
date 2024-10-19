using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Tank : MonoBehaviour
{
    [SerializeField] protected TankMoveController _tankMoveController;

    protected TankInputActionsHolder _tankInputActionsHolder;
    
    protected void Initialize()
    {
        _tankInputActionsHolder = new();
        _tankMoveController.Initialize(_tankInputActionsHolder);
    }
}
