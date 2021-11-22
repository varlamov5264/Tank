using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRed : Enemy
{

    protected override float MoveSpeed => 2.5f;
    protected override float MinDistance => 1.5f;

    public MonsterRed(
        Vector3 position,
        float rotation,
        Area area,
        Transformable target) : base(position, rotation, area, target) { }
}
