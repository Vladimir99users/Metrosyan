using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpellQuickbar : MonoBehaviour
{
    [SerializeField] private List<QuickbarSlot> _slots;

    [SerializeField] private QuickbarSlot _selectedSlot;

    public Spell SelectedSpell => _selectedSlot?.SpellSlot.CurrentItem ?? null;

    private void Awake()
    {
        foreach(var slot in _slots)
        {
            slot.Selected += OnSlotSelected;
        }

        if (_slots.Count > 0)
        {
            _slots[0].Select();
        }
    }

    private void OnSlotSelected(QuickbarSlot slot)
    {
        _selectedSlot?.Diselect();
        _selectedSlot = slot;
    }

}


