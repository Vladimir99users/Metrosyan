using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GolemCraftMenu : Menu, IInputLisener
{
    public SpellUnityEvent SpellCrafted;
    public SpellUnityEvent SpellAdding;

    [SerializeField] private CoreSlot _typeSlot;
    [SerializeField] private CoreSlot _extraSlot;
    [SerializeField] private GolemCastFactory _golemFactory;
    [SerializeField] private AuraFactory _auraFactory;
    [SerializeField] private InputActionReference _openCloseInput;

    private Spell _craftedGolem;
    
    public void Craft()
    {
        if (_typeSlot.CurrentItem is null)
            return;

        _craftedGolem  = _golemFactory.Get(_typeSlot.CurrentItem);

        if(_extraSlot.CurrentItem != null)
        {
            var aura = _auraFactory.Get(_extraSlot.CurrentItem);
            (_craftedGolem as GolemCast).SetStartBuffs(new[] { aura });
        }

        SpellCrafted?.Invoke(_craftedGolem);
    }

    public void AddToSlot()
    {
        if(_craftedGolem is null)
        {
            return;
        }

        SpellAdding?.Invoke(_craftedGolem);
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
