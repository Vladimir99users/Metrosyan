public class MagicBallCraftMenu : DefaultSpellCraftMenu
{
    public override bool TryCraft(out Spell craftedSpell)
    {
        craftedSpell = null;
        if(TypeSlotCraft(out craftedSpell))
        {
            return false;
        }



        return true;

    }
}