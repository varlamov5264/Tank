using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : DamageableCharacter
{

    protected override float MaxHP => 500f;
    protected override float Protect => 0.25f;

    protected override float MoveSpeed => 6f;
    protected override float RotateSpeed => 120f;

    private InputManager _inputManager;
    private List<DefaultWeapon> _weapons;
    private int currentWeaponNum = 0;

    public Tank(Vector3 position,
        float rotation,
        InputManager inputManager,
        Area area) : base(position, rotation, area)
    {
        _inputManager = inputManager;
        _inputManager.onChangeWeaponMinus += OnChangeWeaponMinus;
        _inputManager.onChangeWeaponPlus += OnChangeWeaponPlus;
    }

    public void InitWeapon(List<DefaultWeapon> weapons)
    {
        _weapons = weapons;
        foreach (var weapon in _weapons)
            _inputManager.onFireClick += weapon.OnFireClick;
    }

    public override void Update(float deltaTime)
    {
        base.Update(deltaTime);
        _inputManager?.Update();
        float horizontal = _inputManager.GetAxis(Axis.Horizontal);
        float vectical = _inputManager.GetAxis(Axis.Vertical);
        var direction = Forward * vectical;
        if (!Raycast(direction, 1.5f))
            Move(direction, deltaTime);
        Rotate(horizontal, deltaTime);
    }

    public override void Move(Vector3 shift, float deltaTime)
    {
        base.Move(shift, deltaTime);
        _area.ClampInArea(this);
    }

    public override void OnDisable()
    {
        base.OnDisable();
        foreach (var weapon in _weapons)
            _inputManager.onFireClick -= weapon.OnFireClick;
        _inputManager.onChangeWeaponMinus -= OnChangeWeaponMinus;
        _inputManager.onChangeWeaponPlus -= OnChangeWeaponPlus;
    }


    public void OnChangeWeaponMinus()
    {
        SelectWeapon(-1);
    }

    public void OnChangeWeaponPlus()
    {
        SelectWeapon(1);
    }

    private void SelectWeapon(int dir)
    {
        currentWeaponNum = Mathf.Clamp(currentWeaponNum + dir, 0, _weapons.Count - 1);
        for (int i = 0; i < _weapons.Count; i++)
        {
            _weapons[i].SetActive(i == currentWeaponNum);
        }
    }
}
