public class SpellSlot : Slot<Spell>
{
    public void UseSpell()
    {
        CurrentItem.Use();
    }
}
