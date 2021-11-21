using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankComposite : Composite
{

    [SerializeField] private TransformableView _transformableView;
    [SerializeField] private Area _playerArea;

    private InputManager _inputManager;
    private Tank _model;

    public Tank Model => _model;

    public override void Compose()
    {
        _inputManager = new KeyboardInput();
        _model = new Tank(transform.position,
                          transform.eulerAngles.y,
                          _inputManager,
                          _playerArea);
        _transformableView.Init(_model);
        _inputManager.onFireClick += OnFireClick;
        _inputManager.onChangeWeaponMinus += OnChangeWeaponMinus;
        _inputManager.onChangeWeaponPlus += OnChangeWeaponPlus;
    }

    private void OnDisable()
    {
        _inputManager.onFireClick -= OnFireClick;
        _inputManager.onChangeWeaponMinus -= OnChangeWeaponMinus;
        _inputManager.onChangeWeaponPlus -= OnChangeWeaponPlus;
    }

    private void OnFireClick()
    {

    }

    private void OnChangeWeaponMinus()
    {

    }

    private void OnChangeWeaponPlus()
    {

    }
}
