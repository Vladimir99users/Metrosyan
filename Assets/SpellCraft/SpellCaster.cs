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
        //if (_spellQuickbar.IsSpellSelected == false)
        //    return;

        _spellSign.Show();
    }

    private void OnCastPressed(InputAction.CallbackContext context)
    {
        //if (_spellQuickbar.IsSpellSelected == false)
        //    return;

        if(_spellQuickbar.SelectedSpell is null)
        {
            return;
        }
        var spell = _spellQuickbar.SelectedSpell;

        switch(spell.CastType){
            case CastType.Call:
                spell.Use(_spellSign.Position, Vector3.zero);
                break;
            case CastType.Shoot:
                spell.Use(transform.position, _spellSign.transform.position - transform.position);
                break;
            case CastType.Target:
                spell.Use(transform.position, Vector3.zero, gameObject);
                    break;
            default:
                spell.Use(transform.position, _spellSign.transform.position - transform.position);
                break;
                break;
        }
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
