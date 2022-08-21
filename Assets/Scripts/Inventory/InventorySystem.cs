using TMPro;
using UnityEngine;


public class InventorySystem : Inventory
{
    [SerializeField] private GameObject _prefabs;
    [SerializeField] private Transform _contentTransform;

    public override void UpdateInventory(Core core)
    {
        GameObject Item = Instantiate(_prefabs,_contentTransform);
        var coreSlot = Item.GetComponent<CoreSlot>();
        Debug.Log("testing text = " + core.Stats.Name);
        Debug.Log("testing Type = " + core.Stats.Type);
        Debug.Log("testing Sprite = " + core.Sprite);

        foreach (var iCore in _coresPresent)
        {
            coreSlot.Add(core);
        }
       
    }
}
