using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GolemCraftMenu : DefaultSpellCraftMenu, IInputLisener
{
    public SpellUnityEvent SpellAdding;

    [SerializeField] private InputActionReference _openCloseInput;

    public override Spell CraftedSpell { get; protected set; }

    public override bool IsSpellCrafted { get; protected set; }
    public override void TryCraft()
    {
        if (_typeSlot.CurrentItem is null)
            return;

        CraftedSpell = _typeSlotSpellFactory.Get(_typeSlot.CurrentItem);

        if(_extraSlot.CurrentItem != null)
        {
            var aura = _extraSlotSpellFactory.Get(_extraSlot.CurrentItem);
            (CraftedSpell as GolemCast).SetStartBuffs(new[] { aura });
        }

        SpellCrafted?.Invoke(CraftedSpell);
        IsSpellCrafted = true;
    }

    public void AddToSlot()
    {
        if(CraftedSpell is null)
        {
            return;
        }

        SpellAdding?.Invoke(CraftedSpell);
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
