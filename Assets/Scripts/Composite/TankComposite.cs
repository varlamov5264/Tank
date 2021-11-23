using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankComposite : Composite
{
    [SerializeField] private TransformableView _tankPrefab;
    [SerializeField] private WeaponViewFactory _weaponViewFactory;
    [SerializeField] private BulletsViewFactory _bulletsViewFactory;
    [SerializeField] private Area _playerArea;

    public Tank Model { get; private set; }

    private TransformableView _transformableView;
    private InputManager _inputManager;

    private readonly Vector3 spawnPosition = new Vector3(0, 0.5f, 0);

    public override void Compose()
    {
        _transformableView = Instantiate(_tankPrefab);
        _inputManager = new KeyboardInput();
        Model = new Tank(spawnPosition, 0,
                          _inputManager,
                          _playerArea);
        var _weapons = new List<DefaultWeapon>();
        _weapons.Add(new DefaultWeapon(Model, _bulletsViewFactory));
        foreach (var weapon in _weapons)
            _weaponViewFactory.Create(weapon, _transformableView.transform);
        Model.InitWeapon(_weapons);
        _transformableView.Init(Model);
    }

    private void OnDisable()
    {
        Model.OnDisable();
    }
}
