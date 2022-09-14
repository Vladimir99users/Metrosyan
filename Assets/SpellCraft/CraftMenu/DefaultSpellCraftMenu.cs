using UnityEngine;

[System.Serializable]
public abstract class DefaultSpellCraftMenu : SpellCraftMenu
{
    [SerializeField] protected CoreSlot _typeSlot;
    [SerializeField] protected CoreSlot _extraSlot;

    [SerializeField] protected SpellFactory _typeSlotSpellFactory;
    [SerializeField] protected SpellFactory _extraSlotSpellFactory;

    public virtual bool TypeSlotCraft(out Spell craftedSpell)
    {
        craftedSpell = null;

        if (_typeSlot.CurrentItem is null)
            return false;

        craftedSpell = _typeSlotSpellFactory.Get(_typeSlot.CurrentItem);
        return true;
    }

}
