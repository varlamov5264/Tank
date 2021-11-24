public abstract class Weapon : Kit
{
    public Weapon(Tank tank, BulletsViewFactory bulletsViewFactory)
    {
        _bulletsViewFactory = bulletsViewFactory;
        _tank = tank;
    }

    protected virtual float ReloadTime => 0.05f;
    private bool AllowFire => _currentReloadTime >= ReloadTime;

    private readonly BulletsViewFactory _bulletsViewFactory;
    protected readonly Tank _tank;
    private float _currentReloadTime;

    public override void Update(float deltaTime)
    {
        if (IsActive)
        {
            base.Update(deltaTime);
            _currentReloadTime += deltaTime;
        }
    }

    public void OnFireClick()
    {
        if (IsActive && AllowFire)
        {
            _bulletsViewFactory.Create(GetBullet());
            _currentReloadTime = 0;
        }
    }

    protected virtual Bullet GetBullet()
    {
        return new DefaultBullet(_tank.Position, _tank.Rotation);
    }
}

public class DefaultWeapon : Weapon
{
    public DefaultWeapon(
        Tank tank,
        BulletsViewFactory bulletsViewFactory) : base(tank, bulletsViewFactory) { }
}

public class RocketLauncher : Weapon
{
    public RocketLauncher(
        Tank tank,
        BulletsViewFactory bulletsViewFactory) : base(tank, bulletsViewFactory) { }

    protected override float ReloadTime => 0.5f;

    protected override Bullet GetBullet()
    {
        return new Rocket(_tank.Position, _tank.Rotation);
    }
}