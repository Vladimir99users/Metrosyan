using UnityEngine;

public class AuraFactory : SpellFactory
{
    [SerializeField] private Aura _auraPrefab;

    [SerializeField] private AuraConfig _fireAuraConfig;
    [SerializeField] private AuraConfig _iceAuraConfig;

    public override Spell Get(Core core)
    {
        var newAura = _auraPrefab;
        var attackFactory = new AuraAttackFactory();
        var attack = attackFactory.Get(core.Stats);
        newAura.Init(attack, GetAuraConfig(core));
        return newAura;
    }

    public AuraConfig GetAuraConfig(Core core) => core.Stats.Type switch
    {
        ElementType.Fire => _fireAuraConfig,
        ElementType.Ice => _iceAuraConfig,
        _ => _fireAuraConfig,
    };

}
