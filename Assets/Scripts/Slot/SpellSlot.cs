using UnityEngine;
public class SpellSlot : Slot<Spell>
{
    [SerializeField] private UnityEngine.UI.Image background;
    public void UseSpell()
    {
        if(CurrentItem is null) return;

        background.color = CurrentItem.TypeCore.Color;
        CurrentItem.Use();
    }
}
