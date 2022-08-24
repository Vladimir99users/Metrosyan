using System.Collections.Generic;
using UnityEngine;

public abstract class SpellFactory
{
    public abstract Spell Get();
  
}

public class GolemFactory
{
    public Spell Get(Core mainCore)
    {
        AttackFactoryBase _attaclFactory;
        _attaclFactory = new RangeAttackFactory();

        IAttack attack = _attaclFactory.Get(mainCore.Stats);

        Spell golem = new Golem(attack);
        return golem;
    }
}
