public class RangeAttackFactory : AttackFactoryBase
{
    public override Attack Get(EntityStats stats)
    {
        return new RangeAttack(new Projectale(stats.Damage, stats.Type, stats.Name));
    }
}
