using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputManager
{
    public Action onFireClick;
    public Action onChangeWeaponMinus;
    public Action onChangeWeaponPlus;
    public Action onMoveForward;

    public abstract float GetAxis(string axisName);
    public virtual void Update() { }
}
