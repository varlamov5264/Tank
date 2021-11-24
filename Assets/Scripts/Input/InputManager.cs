using System;

public abstract class InputManager
{
    public Action onFireClick;
    public Action onChangeWeaponMinus;
    public Action onChangeWeaponPlus;
    public Action onMoveForward;

    public abstract float GetAxis(string axisName);
    public virtual void Update() { }
}
