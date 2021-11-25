using UnityEngine;

public class Area : Transformable
{
    
    public Area(
        Vector3 position,
        float rotation, Vector2 size) : base(position, rotation)
    {
        _size = size;
        UpdateBorders();
    }

    public enum Border
    {
        Up = 0, Down = 1, Right = 2, Left = 3
    }

    private float RadiusX => DiameterX / 2;
    private float RadiusY => DiameterY / 2;

    private float DiameterX => _size.x;
    private float DiameterY => _size.y;

    private float BorderUp, BorderDown, BorderRight, BorderLeft;

    private Vector2 _size;

    public bool IsInArea(Transformable model)
    {
        return model.Position.x > BorderLeft &&
               model.Position.x < BorderRight &&
               model.Position.z > BorderDown &&
               model.Position.z < BorderUp;
    }

    public void ClampInArea(Transformable model)
    {
        var x = Mathf.Clamp(model.Position.x, BorderLeft, BorderRight);
        var y = Mathf.Clamp(model.Position.z, BorderDown, BorderUp);
        model.SetPosition(new Vector3(x, 0, y));
    }

    public override void Move(Vector3 shift, float deltaTime)
    {
        base.Move(shift, deltaTime);
        UpdateBorders();
    }

    public override void SetPosition(Vector3 shift)
    {
        base.SetPosition(shift);
        UpdateBorders();
    }

    private void UpdateBorders()
    {
        BorderUp = GetBorder(Border.Up);
        BorderDown = GetBorder(Border.Down);
        BorderRight = GetBorder(Border.Right);
        BorderLeft = GetBorder(Border.Left);
    }

    private float GetBorder(Border border)
    {
        var y = (int)border < 2;
        var radius = y ? RadiusY : RadiusX;
        var output = radius * ((int)border % 2 == 0 ? 1 : -1) + (y ? Position.z : Position.x);
        return output;
    }

    public Vector3 GetRandomPositionOutsideArea()
    {
        var x = GetRandomValue(true);
        var y = GetRandomValue(x < -1 || x > 1);
        return new Vector3(x * DiameterX + Position.x,
                           0,
                           y * DiameterY + Position.y);
    }

    private float GetRandomValue(bool inside)
    {
        var positive = Random.Range(0, 2) == 0;
        var output = Random.Range(inside ? 0f : 1f, 1.25f) * (positive ? 1 : -1);
        return output;
    }
}
