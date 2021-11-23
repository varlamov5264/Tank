using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformableRaycast : Transformable
{
    public TransformableRaycast (
        Vector3 position,
        float rotation
        ) : base(position, rotation) {}

    protected bool Raycast(Vector3 direction, float range = 10)
    {
        float minDist = 0;
        bool foundPlayer = false;
        return Raycast(direction, ref minDist, ref foundPlayer, range);
    }

    protected bool Raycast(Vector3 direction, ref float minDist, ref bool foundPlayer, float range)
    {
        RaycastHit hit;
        bool isPlayer = false;
        var ray = Raycast(direction, out hit, range);
        if (ray)
        {
            if (minDist == 0 || hit.distance < minDist)
                minDist = hit.distance;
            isPlayer = hit.collider.CompareTag(Tags.Player);
            if (isPlayer)
                foundPlayer = true;
            Debug.DrawLine(Position, hit.point, isPlayer ? Color.green : Color.yellow);
        }
        else
        {
            Debug.DrawLine(Position, Position + direction.normalized * range, Color.red);
        }
        return ray && !isPlayer;
    }

    protected bool Raycast(Vector3 direction, out RaycastHit hit, float range)
    {
        return Physics.Raycast(Position, direction, out hit, range);
    }
}
