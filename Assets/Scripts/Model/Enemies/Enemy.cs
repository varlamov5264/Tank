using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : DamageableCharacter
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
    private const int distCoofToAdditionalRaycast = 3;
    private const int raycastCount = 7;
    private const int raycastRange = 7;

    public override void Update(float deltaTime)
    {
        base.Update(deltaTime);
        var distanceToTarget = Vector3.Distance(Position, _target.Position);
        var allowMove = distanceToTarget > MinDistance;
        float minDist = 0;
        bool foundPlayer = false;
        if (_area.IsInArea(this) &&
            allowMove && GroupRaycast(ref minDist, distanceToTarget, ref foundPlayer) && !foundPlayer)
        {
            var forwardObstacle = Raycast(Forward, MinDistance);
            allowMove &= !forwardObstacle;
            if (allowMove || distanceToTarget > MinDistance * 2)
            {
                var rightObstacle = Raycast(Forward + Right);
                var rotateCoof = minDist < 1.5f ? 5 :
                                (minDist < 2 ? 3 :
                                (minDist < 3 ? 2 : 1));
                Rotate(rotateCoof * (rightObstacle ? -1 : 1), deltaTime);
            }
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
        if (allowMove)
            Move(Forward, deltaTime);
    }

    private bool GroupRaycast(ref float minDist, float distanceToTarget, ref bool foundPlayer)
    {
        var forward = Forward;
        var right = Right;
        var spreadCoof = 1;
        var output = false;
        for (int i = 0; i < (distanceToTarget > MinDistance * distCoofToAdditionalRaycast ? raycastCount : 1); i++)
        {
            var direction = forward;
            if (i > 0)
            {
                direction += (right * spread * spreadCoof * (i % 2 == 1 ? 1 : -1));
                if (i % 2 == 0)
                    spreadCoof *= 2;
            }
            output |= Raycast(direction, ref minDist, ref foundPlayer, raycastRange);
            if (foundPlayer)
                return output;
        }
        return output;
    }
}
