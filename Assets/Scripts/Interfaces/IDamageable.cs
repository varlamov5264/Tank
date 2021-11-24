public interface IDamageable
{
    float HP { get; }
    bool IsDead { get; }

    void Damage(float hp);
}
