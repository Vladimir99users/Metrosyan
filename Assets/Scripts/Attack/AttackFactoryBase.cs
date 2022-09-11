/// <summary>
/// Возвращает атаку - стратегию атаки для юнита
/// </summary>
public abstract class AttackFactoryBase
{
    public abstract Attack Get(EntityStats stats);
}