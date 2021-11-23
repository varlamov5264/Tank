using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsViewFactory : TransformableViewFactory<DefaultBullet>
{
    [SerializeField] private TransformableView defaultBullet;

    protected override TransformableView GetTemplate(DefaultBullet model)
    {
        if (model is DefaultBullet)
            return defaultBullet;
        throw new NotImplementedException();
    }
}