using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageableCharacter : TransformableRaycast, IDamageable
{

    public DamageableCharacter(
        Vector3 position,
        float rotation,
        Area area) : base(position, rotation)
    {
        _area = area;
    }

    public float HP => MaxHP - damagedHP;
    public bool IsDead => HP == 0;
    public Action<Transformable> onDead;

    protected virtual float MaxHP => 100f;
    protected virtual float Protect => 1f;

    protected float damagedHP = 0f;
    protected Area _area;

    public virtual void Damage(float hp)
    {
        damagedHP = Mathf.Clamp(damagedHP + hp * Protect, 0, MaxHP);
        if (IsDead)
            onDead?.Invoke(this);
    }
}
