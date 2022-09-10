public class AuraAttackFactory : AttackFactoryBase
{
    public override Attack Get(EntityStats stats)
    {
        return new AuraAttack(stats.Damage, 10f);
    }
}
