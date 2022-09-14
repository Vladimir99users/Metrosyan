using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GolemCraftMenu : DefaultSpellCraftMenu
{
    public SpellUnityEvent SpellAdding;

    [SerializeField] private InputActionReference _openCloseInput;

    private Spell _craftedSpell;
    public override bool TryCraft(out Spell craftedSpell)
    {
        if (TypeSlotCraft(out craftedSpell) == false)
            return false;
            

        if(_extraSlot.CurrentItem != null)
        {
            var aura = _extraSlotSpellFactory.Get(_extraSlot.CurrentItem);
            (craftedSpell as GolemCast).SetStartBuffs(new[] { aura });
        }

        SpellCrafted?.Invoke(craftedSpell);
        return true;
    }

    private void Awake()
    {
        _typeSlot.Added += OnSlotFilled;
        _extraSlot.Added += OnSlotFilled;
    }

    private void OnSlotFilled(Core core)
    {
        if(TryCraft(out Spell spell))
        {
            _craftedSpell = spell;
        }
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
