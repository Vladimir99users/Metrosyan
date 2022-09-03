using UnityEngine;
using UnityEngine.InputSystem;

public class SpellCaster : MonoBehaviour
{
    [SerializeField] private SpellSign _spellSign;
    [SerializeField] private InputActionReference _castInput;
    [SerializeField] private SpellQuickbar _spellQuickbar;


    public void Enable()
    {
        _castInput.action.Enable();
    }

    public void Disable()
    {
        _castInput.action.Disable();
    }

    private void OnEnable()
    {
        Enable();
        _castInput.action.performed += OnCastPressed;
    }


    public void Cast(Spell spell)
    {
        Debug.Log($"Кастую в точку {_spellSign.Position} заклинание {spell.name}");
        spell.Use(_spellSign.Position, Vector3.zero);
    }

    private void OnCastPressed(InputAction.CallbackContext context)
    {
        if (_spellQuickbar.SelectedSpell is null)
        {
            return;
        }
        Spell spell = _spellQuickbar.SelectedSpell;
        Cast(spell);
    }


}
