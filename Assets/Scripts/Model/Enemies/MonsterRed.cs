using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRed : Enemy
{

    protected override float MoveSpeed => 2.5f;

    public MonsterRed(
        Vector3 position,
        float rotation,
        Transformable target) : base(position, rotation, target) { }
}
