using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Transformable
{
    private InputManager _inputManager;
    

    protected override float MoveSpeed => 6f;
    protected override float RotateSpeed => 120f;

    public Tank(Vector3 position, float rotation, InputManager inputManager, Area area) : base(position, rotation, area)
    {
        _inputManager = inputManager;
    }

    public override void Update(float deltaTime)
    {
        base.Update(deltaTime);
        _inputManager?.Update();
        float horizontal = _inputManager.GetAxis(Axis.Horizontal);
        float vectical = _inputManager.GetAxis(Axis.Vertical);
        var direction = Forward * vectical;
        if (!Raycast(direction, 1))
            Move(direction, deltaTime);
        Rotate(horizontal, deltaTime);
    }

    public override void Move(Vector3 shift, float deltaTime)
    {
        base.Move(shift, deltaTime);
        _area.ClampInArea(this);
    }
}
