using UnityEngine;

public abstract class Transformable : Model
{
    public Transformable(Vector3 position, float rotation)
    {
        Position = position;
        Rotation = rotation;
    }

    public Vector3 Position { get; private set; }
    public float Rotation { get; private set; }

    protected virtual float MoveSpeed => 10f;
    protected virtual float RotateSpeed => 60f;

    public Vector3 Forward => GetQuaternion() * Vector3.forward;
    public Vector3 Right => GetQuaternion() * Vector3.right;

    public Quaternion GetQuaternion() => Quaternion.Euler(0, Rotation, 0);

    public virtual void Move(Vector3 shift, float deltaTime)
    {
        Position += shift * MoveSpeed * deltaTime;
    }

    public virtual void SetPosition(Vector3 shift)
    {
        Position = shift;
    }

    public virtual void SetRotation(float rotation)
    {
        Rotation = rotation;
    }

    public void Rotate(float delta, float deltaTime)
    {
        Rotation = Mathf.Repeat(Rotation + delta * RotateSpeed * deltaTime, 360);
    }

    protected void Destroy()
    {
        onDestroy?.Invoke(this);
    }
}
