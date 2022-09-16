using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class SpellCaster : MonoBehaviour, IInputLisener
{

    [SerializeField] private SpellSight _spellSign;
    [SerializeField] private InputActionReference _castInput;
    [SerializeField] private SpellQuickbar _spellQuickbar;
    [SerializeField] private Stamina _stamina;

    public void Cast(Spell spell, Vector3 castPosition = default(Vector3), Vector3 direction = default(Vector3), GameObject target = null)
    {
        if (_stamina.TrySpend(spell.Core.Stats.StaminaCost))
        {
            spell.Use(castPosition, direction, target);
        }
    }
      
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
        _spellSign.Show();
    }
    private void OnCastPressed(InputAction.CallbackContext context)
    {

        if (_spellQuickbar.SelectedSpell is null)
        {
            return;
        }
        var spell = _spellQuickbar.SelectedSpell;

        switch (spell.CastType)
        {
            case CastType.Call:
                Cast(spell, _spellSign.Position, Vector3.zero);
                break;
            case CastType.Shoot:
                Cast(spell, transform.position, _spellSign.transform.position - transform.position);
                break;
            case CastType.Target:
                Cast(spell, transform.position, Vector3.zero, gameObject);
                break;
            default:
                Cast(spell, transform.position, _spellSign.transform.position - transform.position);
                break;
        }

        
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

