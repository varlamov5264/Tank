using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Transformable
{

    public Enemy(
        Vector3 position,
        float rotation,
        Area area,
        Transformable target) : base(position, rotation, area)
    {
        _target = target;
    }

    protected virtual float MinDistance => 1f;

    protected override float RotateSpeed => 60f;
    private readonly float spread = 0.2f;

    private Transformable _target;

    public override void Update(float deltaTime)
    {
        base.Update(deltaTime);
        var distanceToTarget = Vector3.Distance(Position, _target.Position);
        var allowMove = distanceToTarget > MinDistance;
        if (allowMove)
            Move(Forward, deltaTime);
        float minDist = 0;
        if (_area.IsInArea(this) &&
            allowMove &&
            GroupRaycast(ref minDist, distanceToTarget))
        {
            var rotateCoof = minDist < 1.5f ? 5 :
                            (minDist < 2 ? 3 :
                            (minDist < 3 ? 2 : 1));
            Rotation += RotateSpeed * deltaTime * rotateCoof *
                        (Raycast(Forward + Right, ref minDist) ? -1 : 1);
        }
        else
        {
            Vector3 relativePos = _target.Position - Position;
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            var rotateCoof = distanceToTarget < MinDistance * 3 ? 3 : 1;
            Rotation = Mathf.MoveTowardsAngle(Rotation,
                        rotation.eulerAngles.y,
                        RotateSpeed * deltaTime * rotateCoof);
        }
    }

    private bool GroupRaycast(ref float minDist, float distanceToTarget)
    {
        var forward = Forward;
        var right = Right;
        return Raycast(forward, ref minDist) ||
               distanceToTarget > MinDistance * 3 && (
                   Raycast(forward + right * spread, ref minDist) ||
                   Raycast(forward - right * spread, ref minDist) ||
                   Raycast(forward + right * spread * 2, ref minDist) ||
                   Raycast(forward - right * spread * 2, ref minDist) ||
                   Raycast(forward + right * spread * 4, ref minDist, 5) ||
                   Raycast(forward - right * spread * 4, ref minDist, 5));
    }
}
