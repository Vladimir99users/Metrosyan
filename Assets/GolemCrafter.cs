using System.Collections.Generic;
using UnityEngine;

public class GolemCrafter : MonoBehaviour
{
    [SerializeField] private CoreSlot _typeSlot;
    private AttackFactoryBase _attackFactory = new RangeAttackFactory();

    public Inventory Inventory;
    public void Craft()
    {
        if (_typeSlot.Item is null)
            return;

        
        Inventory.AddInventoryAction?.Invoke(_typeSlot);
        IAttack golemAttack = _attackFactory.Get(_typeSlot.Item.Stats);
        Spell golem = new Golem(golemAttack);
        golem.Use();
    }  
}
