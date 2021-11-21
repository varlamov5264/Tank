using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Transformable
{

    public Enemy(
    Vector3 position,
    float rotation,
    Transformable target) : base(position, rotation)
    {
        _target = target;
    }

    protected override float RotateSpeed => 60f;
    private float minDistance = 5;

    private Transformable _target;

    public override void Update()
    {
        base.Update();
        //Position = Vector3.MoveTowards(Position, _target.Position, MoveSpeed * Time.deltaTime);
        if (Vector3.Distance(Position, _target.Position) > minDistance)
            Move(Forward);
        Vector3 relativePos = _target.Position - Position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        Rotation = Mathf.MoveTowardsAngle(Rotation, rotation.eulerAngles.y, RotateSpeed * Time.deltaTime);
    }
}
