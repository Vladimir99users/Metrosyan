using TMPro;

public class SpellSlot : Slot<Spell>
{
    public void UseSpell()
    {
        CurrentItem.Use(transform.position, transform.forward);
    }
}
