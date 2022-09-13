using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class SpellQuickbar : MonoBehaviour, IInputLisener
{
    public bool IsSpellSelected => _selectedSlot != null;
    public Spell SelectedSpell => _selectedSlot.SpellSlot.CurrentItem;

    [SerializeField] private List<QuickbarSlot> _slots;

    [SerializeField] private QuickbarSlot _selectedSlot;


    public void AddSpell(Spell spell)
    {
        if (_selectedSlot is null)
            return;

        _selectedSlot.SpellSlot.Add(spell);
    }
    public void EnableInput()
    {
        foreach(var slot in _slots)
        {
            slot.EnableInput();
        }
    }

    public void DisableInput()
    {
        foreach (var slot in _slots)
        {
            slot.DisableInput();
        }
    }

    private void OnEnable()
    {
        foreach (var slot in _slots)
        {
            slot.Selected += OnSlotSelected;
            slot.Diselected += OnSlotDiselected;
        }
    }

    private void OnDisable()
    {
        foreach (var slot in _slots)
        {
            slot.Selected -= OnSlotSelected;
            slot.Diselected -= OnSlotDiselected;
        }
    }

    private void OnSlotSelected(QuickbarSlot slot)
    {
        if (slot == _selectedSlot)
        {
            return;
        }

        _selectedSlot?.Diselect();

        SetSelectedSlot(slot);
    }

    private void OnSlotDiselected(QuickbarSlot slot)
    {
        if (slot == _selectedSlot)
        {
            ClearSelectedSlot();
        }
    }

    private void SetSelectedSlot(QuickbarSlot slot)
    {
        _selectedSlot = slot;
    }

    private void ClearSelectedSlot()
    {
        _selectedSlot = null;
    }

}


