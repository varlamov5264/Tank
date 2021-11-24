using System;
using UnityEngine;

public class BulletsViewFactory : TransformableViewFactory<Bullet>
{
    [SerializeField] private TransformableView _defaultBullet;
    [SerializeField] private TransformableView _rocket;

    protected override TransformableView GetTemplate(Bullet model)
    {
        if (model is DefaultBullet)
            return _defaultBullet;
        if (model is Rocket)
            return _rocket;
        throw new NotImplementedException();
    }
}