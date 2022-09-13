using System.Collections.Generic;
using UnityEngine;

public class GolemCastFactory : SpellFactory
{
    [SerializeField] private Golem _fireGolem;
    [SerializeField] private Golem _iceGolem;

    [SerializeField] private GolemCast _golemCastPrefab;

    [SerializeField] private GolemCaster _golemCaster;

    public override Spell Get(Core mainCore)
    {
        AttackFactoryBase _attackFactory;
        _attackFactory = new RangeAttackFactory();

        Attack attack = _attackFactory.Get(mainCore.Stats);

        var golem = GetGolemByType(mainCore);

        GolemCast golemCast = Instantiate(_golemCastPrefab);
        golemCast.Init(golem, attack, _golemCaster);
        
        return golemCast;
    }

    private Golem GetGolemByType(Core core) => core.Stats.Type switch
    {
        ElementType.Fire => _fireGolem,
        ElementType.Ice => _iceGolem,
        _ => _fireGolem,
    };
}
