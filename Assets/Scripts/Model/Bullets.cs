using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBullet : TransformableRaycast
{

    protected override float MoveSpeed => 50f;
    public virtual float DamageHP => 100f;
    protected virtual float DestroyTime => 2f;

    private Timer destroyTimer;

    public DefaultBullet(
        Vector3 position,
        float rotation) : base(position, rotation)
    {
        destroyTimer = new Timer(DestroyTime, Destroy);
    }

    public override void Update(float deltaTime)
    {
        base.Update(deltaTime);
        Move(Forward, deltaTime);
        RaycastHit hit;
        if (Raycast(Forward, out hit, 1f))
        {
            if (hit.collider.TryGetComponent(out TransformableView transformableView))
            {
                if (transformableView.Model is DamageableCharacter)
                {
                    var character = (DamageableCharacter)transformableView.Model;
                    character.Damage(DamageHP);
                }
            }
            Destroy();
        }
        destroyTimer.AddTime(deltaTime);
    }
}
