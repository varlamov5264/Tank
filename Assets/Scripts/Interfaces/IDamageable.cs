using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public float HP { get; }
    public bool IsDead { get; }

    public void Damage(float hp);
}
