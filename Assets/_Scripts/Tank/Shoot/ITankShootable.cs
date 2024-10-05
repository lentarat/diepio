using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface ITankShootable
{
    public static Action OnShot;
    Vector3 GetAimWorldPosition();
}
