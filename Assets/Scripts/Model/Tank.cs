using UnityEngine;

public class Tank : Character
{
    public Tank(Vector3 position,
        float rotation,
        Area area,
        InputManager inputManager) : base(position, rotation, area)
        {
            _inputManager = inputManager;
        }

    protected override float MaxHP => 500f;
    protected override float Protect => 0.25f;

    protected override float MoveSpeed => 6f;
    protected override float RotateSpeed => 120f;

    private readonly InputManager _inputManager;
    private Weapons _weapons;

    public void AddWeapons(Weapons weapons)
    {
        _weapons = weapons;
    }

    public override void Update(float deltaTime)
    {
        base.Update(deltaTime);
        _inputManager?.Update();
        float horizontal = _inputManager.GetAxis(Axis.Horizontal);
        float vectical = _inputManager.GetAxis(Axis.Vertical);
        var direction = Forward * vectical;
        if (!Raycast(direction, 1.5f))
            Move(direction, deltaTime);
        Rotate(horizontal, deltaTime);
    }

    public override void Move(Vector3 shift, float deltaTime)
    {
        base.Move(shift, deltaTime);
        _area.ClampInArea(this);
    }

    public override void OnDisable()
    {
        base.OnDisable();
        _weapons.OnDisable();
    }
}
