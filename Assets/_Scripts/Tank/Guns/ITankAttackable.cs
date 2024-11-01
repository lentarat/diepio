using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface ITankAttackable
{
    event Action OnFinishedFiring;
    event Action OnStartedFiring;
    Vector3 GetAimWorldPosition();
}
