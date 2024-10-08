using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface ITankShootable
{
    event Action OnShotFired;
    Vector3 GetAimWorldPosition();
}
