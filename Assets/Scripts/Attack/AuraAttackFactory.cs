public class AuraAttackFactory : AttackFactoryBase
{
    public override IAttack Get(EntityStats stats)
    {
        return new AuraAttack(stats.Damage, 10f);
    }
}
