using System.Collections.Generic;
using UnityEngine;

public class GolemCrafter : MonoBehaviour
{
    [SerializeField] private Core _typeCore;
    private AttackFactoryBase _attackFactory = new RangeAttackFactory();

    public void Craft()
    {
        IAttack golemAttack = _attackFactory.Get(_typeCore.Stats);
        Spell golem = new Golem(golemAttack);
        golem.Use();
    }
  
}
