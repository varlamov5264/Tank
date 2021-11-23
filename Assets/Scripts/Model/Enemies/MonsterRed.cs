using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRed : Enemy
{

    protected override float MaxHP => 200f;
    protected override float Protect => 0.5f;

    protected override float MoveSpeed => 2.5f;
    protected override float MinDistance => 2f;

    public MonsterRed(
        Vector3 position,
        float rotation,
        Area area,
        Transformable target) : base(position, rotation, area, target) { }
}
