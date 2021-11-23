using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultWeapon : Kit
{
    private BulletsViewFactory _bulletsViewFactory;
    private Tank _tank;

    public DefaultWeapon(Tank tank, BulletsViewFactory bulletsViewFactory)
    {
        _bulletsViewFactory = bulletsViewFactory;
        _tank = tank;
    }

    public void OnFireClick()
    {
        _bulletsViewFactory.Create(GetBullet());
    }

    protected virtual DefaultBullet GetBullet()
    {
        return new DefaultBullet(_tank.Position, _tank.Rotation);
    }
}