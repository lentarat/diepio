using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] private TankMoveController _tankMoveController;
    [SerializeField] private TankShootController _tankShootController;

    private void Awake()
    {
        //InjectDependencies();
    }

    //private void InjectDependencies()
    //{ 
    //    _tankMoveController.Initialize()
    //}
}
