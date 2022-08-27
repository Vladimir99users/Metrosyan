using System.Collections.Generic;
using UnityEngine;

public class GolemFactory : MonoBehaviour 
{
    [SerializeField] private Golem _golem;
    public Spell Get(Core mainCore)
    {
        AttackFactoryBase _attaclFactory;
        _attaclFactory = new RangeAttackFactory();

        IAttack attack = _attaclFactory.Get(mainCore.Stats);

        Spell golem = _golem;
        _golem.Init(attack, mainCore);

        return golem;
    }
}
