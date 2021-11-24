using UnityEngine;

public abstract class Bullet : TransformableRaycast
{
    public Bullet(
        Vector3 position,
        float rotation) : base(position, rotation)
    {
        _destroyTimer = new Timer(DestroyTime, Destroy);
    }

    protected override float MoveSpeed => 25f;
    public virtual float DamageHP => 100f;
    protected virtual float DestroyTime => 2f;
    protected virtual float BulletRadius => 0.8f;

    private readonly Timer _destroyTimer;

    public override void Update(float deltaTime)
    {
        base.Update(deltaTime);
        Move(Forward, deltaTime);
    }

    public override void FixedUpdate(float deltaTime)
    {
        base.FixedUpdate(deltaTime);
        if (Raycast(Position - Forward * BulletRadius, Forward, out RaycastHit hit, BulletRadius))
        {
            if (!hit.collider.CompareTag(Tags.Player))
            {
                if (hit.collider.TryGetComponent(out TransformableView transformableView))
                {
                    if (transformableView.Model is Character)
                    {
                        var character = (Character)transformableView.Model;
                        character.Damage(DamageHP);
                    }
                }
                Destroy();
            }
        }
        _destroyTimer.AddTime(deltaTime);
    }
}

public class DefaultBullet : Bullet
{
    public DefaultBullet(
        Vector3 position,
        float rotation) : base(position, rotation) { }
}

public class Rocket : Bullet
{
    public Rocket(
        Vector3 position,
        float rotation) : base(position, rotation) { }

    protected override float MoveSpeed => 10f;
    public override float DamageHP => 500f;
    protected override float DestroyTime => 10f;
    protected override float BulletRadius => 1f;
}

