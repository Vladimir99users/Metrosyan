using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GolemCraftMenu : Menu
{
    public SpellUnityEvent SpellCrafted;
    public SpellUnityEvent SpellAdding;

    [SerializeField] private CoreSlot _typeSlot;
    [SerializeField] private CoreSlot _extraSlot;
    [SerializeField] private GolemFactory _golemFactory;

    private Spell _craftedGolem;

    public void Craft()
    {
        if (_typeSlot.CurrentItem is null)
            return;

        _craftedGolem  = _golemFactory.Get(_typeSlot.CurrentItem);
        SpellCrafted?.Invoke(_craftedGolem);
    }

    public void AddToSlot()
    {
        if(_craftedGolem is null)
        {
            return;
        }

        SpellAdding?.Invoke(_craftedGolem);
    }

    public override void Open()
    {
        gameObject.SetActive(true);
        base.Open();
    }

    public override void Close()
    {
        gameObject.SetActive(false);
        base.Close();
    }
}

[System.Serializable]
public class SpellUnityEvent : UnityEvent<Spell> { }
