using UnityEngine;

public class AuraFactory : SpellFactory
{
    [SerializeField] private Aura _auraPrefab;

    [SerializeField] private AuraConfig _fireAuraConfig;

    public override Spell Get(Core core)
    {
        var newAura = Instantiate(_auraPrefab);
        var attackFactory = new AuraAttackFactory();
        var attack = attackFactory.Get(core.Stats);
        newAura.Init(attack, _fireAuraConfig);
        return newAura;
    }

}
