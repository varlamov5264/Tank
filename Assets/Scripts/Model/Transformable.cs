using UnityEngine;

public abstract class Transformable
{
    public Vector3 Position;
    public float Rotation;
    protected virtual float MoveSpeed => 10f;
    protected virtual float RotateSpeed => 60f;

    public Vector3 Forward => Quaternion.Euler(0, Rotation, 0) * Vector3.forward;

    public Transformable(Vector3 position, float rotation)
    {
        Position = position;
        Rotation = rotation;
    }

    public virtual void Move(Vector3 shift)
    {
        Position += shift * MoveSpeed * Time.deltaTime;
    }

    public void Rotate(float delta)
    {
        Rotation = Mathf.Repeat(Rotation + delta * RotateSpeed * Time.deltaTime, 360);
    }

    public virtual void Update() { }
}
