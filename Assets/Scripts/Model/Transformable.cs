using System;
using UnityEngine;

public abstract class Transformable : Model
{
    public Vector3 Position;
    public float Rotation;
    
    protected virtual float MoveSpeed => 10f;
    protected virtual float RotateSpeed => 60f;

    public Vector3 Forward => GetQuaternion() * Vector3.forward;
    public Vector3 Right => GetQuaternion() * Vector3.right;

    public Action<Transformable> onDestroy;

    public Quaternion GetQuaternion() => Quaternion.Euler(0, Rotation, 0);

    public Transformable(Vector3 position, float rotation)
    {
        Position = position;
        Rotation = rotation;
    }

    public virtual void Move(Vector3 shift, float deltaTime)
    {
        Position += shift * MoveSpeed * deltaTime;
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
