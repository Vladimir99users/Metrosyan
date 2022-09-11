public class RangeAttackFactory : AttackFactoryBase
{
    private ElementType _elementType;

    public override IAttack Get(EntityStats stats)
    {
        return new RangeAttack(new Projectale(stats.Damage, stats.Type, stats.Name));
    }
}