using UnityEngine;

public abstract class Transformable
{
    public Vector3 Position;
    public float Rotation;
    protected Area _area;
    protected virtual float MoveSpeed => 10f;
    protected virtual float RotateSpeed => 60f;

    public Vector3 Forward => GetQuaternion() * Vector3.forward;
    public Vector3 Right => GetQuaternion() * Vector3.right;

    public Quaternion GetQuaternion() => Quaternion.Euler(0, Rotation, 0);

    public Transformable(Vector3 position, float rotation, Area area)
    {
        Position = position;
        Rotation = rotation;
        _area = area;
    }

    public virtual void Move(Vector3 shift, float deltaTime)
    {
        Position += shift * MoveSpeed * deltaTime;
    }

    public void Rotate(float delta, float deltaTime)
    {
        Rotation = Mathf.Repeat(Rotation + delta * RotateSpeed * deltaTime, 360);
    }

    public virtual void Update(float deltaTime) { }

    protected bool Raycast(Vector3 direction, float range = 10)
    {
        float minDist = 0;
        return Raycast(direction, ref minDist, range);
    }

    protected bool Raycast(Vector3 direction, ref float minDist, float range = 10)
    {
        RaycastHit hit;
        bool isPlayer = false;
        var ray = Physics.Raycast(Position, direction, out hit, range);
        if (ray)
        {
            Debug.DrawLine(Position, hit.point, Color.green);
            if (minDist == 0 || hit.distance < minDist)
                minDist = hit.distance;
            isPlayer = hit.collider.CompareTag("Player");
        }
        else
        {
            Debug.DrawLine(Position, Position + direction.normalized * range, Color.red);
        }
        return ray && !isPlayer;
    }
}
