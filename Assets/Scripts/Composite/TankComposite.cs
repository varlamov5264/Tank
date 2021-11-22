using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankComposite : Composite
{
    [SerializeField] private TransformableView _tankPrefab;
    [SerializeField] private Area _playerArea;

    public Tank Model => _model;

    private TransformableView _transformableView;
    private InputManager _inputManager;
    private Tank _model;
    private readonly Vector3 spawnPosition = new Vector3(0, 0.5f, 0);


    public override void Compose()
    {
        _transformableView = Instantiate(_tankPrefab);
        _inputManager = new KeyboardInput();
        _model = new Tank(spawnPosition, 0,
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
