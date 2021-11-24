using System.Collections.Generic;
using UnityEngine;

public class Weapons : Model
{
    public Weapons(List<Weapon> list, InputManager inputManager)
    {
        _list = list;
        _inputManager = inputManager;
        foreach (var weapon in _list)
            _inputManager.onFireClick += weapon.OnFireClick;
        _inputManager.onChangeWeaponMinus += OnChangeWeaponMinus;
        _inputManager.onChangeWeaponPlus += OnChangeWeaponPlus;
        SelectWeapon();
    }

    private readonly List<Weapon> _list;
    private readonly InputManager _inputManager;
    private int _currentWeaponNum = 0;

    public void OnChangeWeaponMinus()
    {
        SelectWeapon(-1);
    }

    public void OnChangeWeaponPlus()
    {
        SelectWeapon(1);
    }

    private void SelectWeapon(int dir = 0)
    {
        _currentWeaponNum = Mathf.Clamp(_currentWeaponNum + dir, 0, _list.Count - 1);
        for (int i = 0; i < _list.Count; i++)
        {
            _list[i].SetActive(i == _currentWeaponNum);
        }
    }

    public override void OnDisable()
    {
        base.OnDisable();
        foreach (var weapon in _list)
            _inputManager.onFireClick -= weapon.OnFireClick;
        _inputManager.onChangeWeaponMinus -= OnChangeWeaponMinus;
        _inputManager.onChangeWeaponPlus -= OnChangeWeaponPlus;
    }
}
