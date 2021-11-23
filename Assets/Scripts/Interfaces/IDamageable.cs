using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    float HP { get; }
    bool IsDead { get; }

    void Damage(float hp);
}
