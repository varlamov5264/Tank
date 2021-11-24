using System;
using UnityEngine;

public abstract class Character : TransformableRaycast, IDamageable
{
    public Character(
        Vector3 position,
        float rotation,
        Area area) : base(position, rotation)
    {
        _area = area;
    }

    public float HP => MaxHP - _damagedHP;
    public bool IsDead => HP == 0;
    public Action<string> onAnimationPlay;
    public Action<float> onDamage;

    protected virtual float MaxHP => 100f;
    protected virtual float Protect => 1f;

    protected float _damagedHP = 0f;
    protected readonly Area _area;

    public virtual void Damage(float hp)
    {
        _damagedHP = Mathf.Clamp(_damagedHP + hp * Protect, 0, MaxHP);
        onDamage?.Invoke(HP);
        if (IsDead)
            Destroy();
    }

    protected void AnimationPlay(string animationName)
    {
        onAnimationPlay?.Invoke(animationName);
    }
}
