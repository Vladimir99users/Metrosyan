public class MagicBallCraftMenu : DefaultSpellCraftMenu
{
    private Spell _craftedSpell;
    public override bool TryCraft(out Spell craftedSpell)
    {
        craftedSpell = null;

        if(TypeSlotCraft(out craftedSpell) == false)
        {
            return false;
        }
         
        SpellCrafted?.Invoke(craftedSpell);
        return true;

    }

    private void Awake()
    {
        _typeSlot.Added += OnSlotFilled;
    }

    private void OnSlotFilled(Core core)
    {
        if (TryCraft(out Spell spell))
        {
            _craftedSpell = spell;
        }
    }
}