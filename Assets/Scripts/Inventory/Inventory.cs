using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Inventory : MonoBehaviour
{
    [SerializeField] protected List<CoreSlot> _coresPresent = new List<CoreSlot>();
    public IEnumerable<List<CoreSlot>> Cores => (IEnumerable<List<CoreSlot>>)_coresPresent;
    public System.Action<CoreSlot> AddInventoryAction;
    public virtual void AddSpell(CoreSlot core) 
    {
        _coresPresent.Add(core);
        UpdateInventory(core.Item);
    }
    public virtual void RemoveSpell() { }
    public abstract void UpdateInventory(Core core);
   

    private void OnEnable()
    {
        AddInventoryAction += AddSpell;
    }

    private void OnDisable()
    {
        AddInventoryAction -= AddSpell;
    }
    
}
