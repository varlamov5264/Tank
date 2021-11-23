using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankComposite : Composite
{
    [SerializeField] private TransformableView _tankPrefab;
    [SerializeField] private Area _playerArea;

    public Tank Model { get; private set; }

    private TransformableView _transformableView;
    private InputManager _inputManager;
    private List<DefaultWeapon> _weapons = new List<DefaultWeapon>();

    private readonly Vector3 spawnPosition = new Vector3(0, 0.5f, 0);

    public override void Compose()
    {
        _transformableView = Instantiate(_tankPrefab);
        _inputManager = new KeyboardInput();
        Model = new Tank(spawnPosition, 0,
                          _inputManager,
                          _playerArea);
        _weapons.Add(new DefaultWeapon());
        foreach (var weapon in _weapons)
            _inputManager.onFireClick += weapon.OnFireClick;
        _inputManager.onChangeWeaponMinus += Model.OnChangeWeaponMinus;
        _inputManager.onChangeWeaponPlus += Model.OnChangeWeaponPlus;
        _transformableView.Init(Model);
    }

    private void OnDisable()
    {
        foreach (var weapon in _weapons)
            _inputManager.onFireClick -= weapon.OnFireClick;
        _inputManager.onChangeWeaponMinus -= Model.OnChangeWeaponMinus;
        _inputManager.onChangeWeaponPlus -= Model.OnChangeWeaponPlus;
    }
}
