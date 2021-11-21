using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : InputManager
{
    [SerializeField] private KeyCode _fireClickButton = KeyCode.X;
    [SerializeField] private KeyCode _changeWeaponMinusButton = KeyCode.Q;
    [SerializeField] private KeyCode _changeWeaponPlusButton = KeyCode.W;

    public override float GetAxis(string axisName)
    {
        return Input.GetAxis(axisName);
    }

    public override void Update()
    {
        if (Input.GetKeyDown(_fireClickButton))
            onFireClick?.Invoke();
        if (Input.GetKeyDown(_changeWeaponMinusButton))
            onChangeWeaponMinus?.Invoke();
        if (Input.GetKeyDown(_changeWeaponPlusButton))
            onChangeWeaponPlus?.Invoke();
    }
}
