using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponViewFactory : KitViewFactory<DefaultWeapon>
{

    [SerializeField] private KitView defaultWeapon;

    protected override KitView GetTemplate(Kit model)
    {
        if (model is DefaultWeapon)
            return defaultWeapon;
        throw new System.NotImplementedException();
    }
}
