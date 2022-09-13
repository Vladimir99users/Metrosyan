public abstract class SpellCraftMenu : Menu
{
    public SpellUnityEvent SpellCrafted;

    public abstract void TryCraft();
    public abstract bool IsSpellCrafted { get; protected set; }
    public abstract Spell CraftedSpell { get; protected set; }
}

public class MagicBallCraftMenu : DefaultSpellCraftMenu
{
    public override Spell CraftedSpell { get; protected set; }

    public override bool IsSpellCrafted { get; protected set; }
    public override void TryCraft()
    {
        throw new System.NotImplementedException();
    }
}