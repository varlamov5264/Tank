using UnityEngine;

public class MonsterOrange : Enemy
{
    public MonsterOrange(
        Vector3 position,
        float rotation,
        Area area,
        Character target) : base(position, rotation, area, target) { }

    protected override float MaxHP => 100f;
    protected override float Protect => 0.7f;
    protected override float DamageHP => 20f;

    protected override float MoveSpeed => 3f;
    protected override float MinDistance => 1.5f;
}
