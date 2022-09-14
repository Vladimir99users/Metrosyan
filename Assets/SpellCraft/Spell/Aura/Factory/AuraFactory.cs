using UnityEngine;

public class AuraFactory : SpellFactory
{
    [SerializeField] private Aura _auraPrefab;
    [SerializeField] private AuraConfigFactoryPrefabs _prefabs;
    public override Spell Get(Core core)
    {
        var newAura = _auraPrefab;
        var attackFactory = new AuraAttackFactory();
        var attack = attackFactory.Get(core.Stats);
        newAura.Init(attack, _prefabs.GetPrefab(core));
        return newAura;
    }

}
