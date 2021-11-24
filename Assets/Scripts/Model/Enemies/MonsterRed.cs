using UnityEngine;

public class MonsterRed : Enemy
{
    public MonsterRed(
        Vector3 position,
        float rotation,
        Area area,
        Character target) : base(position, rotation, area, target) { }

    protected override float MaxHP => 200f;
    protected override float Protect => 0.5f;
    protected override float DamageHP => 30f;

    protected override float MoveSpeed => 2.5f;
    protected override float MinDistance => 2f;
}
