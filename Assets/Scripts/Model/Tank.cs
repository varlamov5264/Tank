using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Transformable
{
    private InputManager _inputManager;
    private Area _area;

    protected override float MoveSpeed => 6f;
    protected override float RotateSpeed => 120f;

    public Tank(Vector3 position, float rotation, InputManager inputManager, Area area) : base(position, rotation)
    {
        _inputManager = inputManager;
        _area = area;
    }

    public override void Update()
    {
        base.Update();
        _inputManager?.Update();
        float horizontal = _inputManager.GetAxis(Axis.Horizontal);
        float vectical = _inputManager.GetAxis(Axis.Vertical);
        Move(Forward * vectical);
        Rotate(horizontal);
    }

    public override void Move(Vector3 shift)
    {
        base.Move(shift);
        Position.x = Mathf.Clamp(Position.x, -_area.size.x / 2, _area.size.x / 2);
        Position.z = Mathf.Clamp(Position.z, -_area.size.y / 2, _area.size.y / 2);
    }
}
