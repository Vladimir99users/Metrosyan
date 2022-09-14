public abstract class SpellCraftMenu : Menu
{
    public SpellUnityEvent SpellCrafted;

    public abstract bool TryCraft(out Spell craftedSpell);
}

