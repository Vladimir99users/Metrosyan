using UnityEngine;

public abstract class DefaultSpellCraftMenu : SpellCraftMenu
{
    [SerializeField] protected CoreSlot _typeSlot;
    [SerializeField] protected CoreSlot _extraSlot;

    [SerializeField] protected SpellFactory _typeSlotSpellFactory;
    [SerializeField] protected SpellFactory _extraSlotSpellFactory;
}
