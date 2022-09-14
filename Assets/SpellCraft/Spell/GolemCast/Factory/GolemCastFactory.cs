using System.Collections.Generic;
using UnityEngine;

public class GolemCastFactory : SpellFactory
{
    [SerializeField] private GolemCast _golemCastPrefab;
    [SerializeField] private GolemCastFactoryPrefabs _prefabs;
    public override Spell Get(Core mainCore)
    {
        AttackFactoryBase _attackFactory;
        _attackFactory = new RangeAttackFactory();

        Attack attack = _attackFactory.Get(mainCore.Stats);

        Golem golem = _prefabs.GetPrefab(mainCore);

        GolemCast golemCast = Instantiate(_golemCastPrefab);
        golemCast.Init(golem, attack);
        
        return golemCast;
    }

}
