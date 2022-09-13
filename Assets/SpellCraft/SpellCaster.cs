using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpellCaster : MonoBehaviour, IInputLisener
{
    [SerializeField] private SpellSight _spellSign;
    [SerializeField] private InputActionReference _castInput;
    [SerializeField] private SpellQuickbar _spellQuickbar;

    private void OnEnable()
    {
        EnableInput();
        _castInput.action.started += OnCastStart;
        _castInput.action.performed += OnCastPressed;

        _spellSign.Hide();

    }


    private void OnDisable()
    {
        DisableInput();
        _castInput.action.performed -= OnCastPressed;
        _castInput.action.started -= OnCastStart;

    }

    private void OnCastStart(InputAction.CallbackContext obj)
    {
        if (_spellQuickbar.IsSpellSelected == false)
            return;

        _spellSign.Show();
    }

    private void OnCastPressed(InputAction.CallbackContext context)
    {
        if (_spellQuickbar.IsSpellSelected == false)
            return;
        
        Cast(_spellQuickbar.SelectedSpell);
    }

    public void Cast(Spell spell)
    {
        Debug.Log($"Я кастую в позицию {_spellSign.Position} заклинание");
        spell.Use(_spellSign.Position, Vector3.zero);
    }

    public void EnableInput()
    {
        _castInput.action.Enable();
        _spellSign.EnableInput();
    }

    public void DisableInput()
    {
        _castInput.action.Disable();
        _spellSign.DisableInput();
    }
}
