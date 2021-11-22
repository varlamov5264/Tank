using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterOrange : Enemy
{

    protected override float MoveSpeed => 3f;

    public MonsterOrange(
        Vector3 position,
        float rotation,
        Area area,
        Transformable target) : base(position, rotation, area, target) { }
}
