using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterOrange : Enemy
{

    protected override float MaxHP => 100f;
    protected override float Protect => 0.7f;

    protected override float MoveSpeed => 3f;
    protected override float MinDistance => 1.5f;

    public MonsterOrange(
        Vector3 position,
        float rotation,
        Area area,
        Transformable target) : base(position, rotation, area, target) { }
}
