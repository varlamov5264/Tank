using UnityEngine;

public class WeaponViewFactory : KitViewFactory<Weapon>
{
    [SerializeField] private KitView _defaultWeapon;
    [SerializeField] private KitView _rocketLauncher;

    protected override KitView GetTemplate(Weapon model)
    {
        if (model is DefaultWeapon)
            return _defaultWeapon;
        else if (model is RocketLauncher)
            return _rocketLauncher;
        throw new System.NotImplementedException();
    }
}
