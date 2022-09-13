using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GolemCraftMenu : DefaultSpellCraftMenu, IInputLisener
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

    public void EnableInput()
    {
        _openCloseInput.action.Enable();
    }

    public void DisableInput()
    {
        _openCloseInput.action.Disable();
    }


    protected override void OnAwake()
    {
        base.OnAwake();

        _openCloseInput.action.Enable();

        _openCloseInput.action.performed += (c) =>
        {
            if (IsOpen)
            {
                Close();
            }
            else
            {
                Open();
            }
        };
    }


}

[System.Serializable]
public class SpellUnityEvent : UnityEvent<Spell> { }
