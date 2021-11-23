using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBullet : TransformableRaycast
{

    protected override float MoveSpeed => 100f;
    public virtual float DamageHP => 100f;
    public Action<Transformable> onDestroy;

    public DefaultBullet(
        Vector3 position,
        float rotation) : base(position, rotation) { }

    public override void Update(float deltaTime)
    {
        base.Update(deltaTime);
        Move(Forward, deltaTime);
        RaycastHit hit;
        if (Raycast(Forward, out hit, 0.1f))
        {
            if (hit.collider.TryGetComponent(out TransformableView transformableView))
            {
                if (transformableView.Model is DamageableCharacter)
                {
                    var character = (DamageableCharacter)transformableView.Model;
                    character.Damage(DamageHP);
                    onDestroy?.Invoke(this);
                }
            }
        }
    }
}
