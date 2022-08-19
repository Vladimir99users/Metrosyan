using System.Collections.Generic;
using UnityEngine;

public class GolemCrafter : MonoBehaviour
{
    [SerializeField] private CoreSlot _typeSlot;
    private AttackFactoryBase _attackFactory = new RangeAttackFactory();

    public void Craft()
    {
        if (_typeSlot.Item is null)
            return;

        IAttack golemAttack = _attackFactory.Get(_typeSlot.Item.Stats);
        Spell golem = new Golem(golemAttack);
        golem.Use();
    }
  
}
