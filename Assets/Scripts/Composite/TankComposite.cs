using System.Collections.Generic;
using UnityEngine;

public class TankComposite : Composite
{
    [SerializeField] private TransformableView _tankPrefab;
    [SerializeField] private WeaponViewFactory _weaponViewFactory;
    [SerializeField] private BulletsViewFactory _bulletsViewFactory;
    [SerializeField] private Area _playerArea;
    [SerializeField] private HUD _hud;

    private Tank _model;
    public Tank Model => _model;

    private TransformableView _transformableView;
    private InputManager _inputManager;

    private readonly Vector3 _spawnPosition = new Vector3(0, 0.5f, 0);

    public override void Compose()
    {
        _transformableView = Instantiate(_tankPrefab);
        _inputManager = new KeyboardInput();

        _model = new Tank(_spawnPosition, 0,
                 _playerArea,
                 _inputManager);

        var weaponsList = new List<Weapon>();
        weaponsList.Add(new DefaultWeapon(_model, _bulletsViewFactory));
        weaponsList.Add(new RocketLauncher(_model, _bulletsViewFactory));
        foreach (var weapon in weaponsList)
            _weaponViewFactory.Create(weapon, _transformableView.transform);
        var weapons = new Weapons(weaponsList, _inputManager);
        _model.AddWeapons(weapons);
        _model.onDestroy += DestroyModel;
        _transformableView.Init(_model);
        _hud.Subscribe(_model);
    }

    protected override void DestroyModel(Model model)
    {
        OnDisable();
        Destroy(_transformableView.gameObject);
        _model = null;
    }

    private void OnDisable()
    {
        if (_model != null)
        {
            _model.onDestroy -= DestroyModel;
            _model.OnDisable();
        }
    }
}
