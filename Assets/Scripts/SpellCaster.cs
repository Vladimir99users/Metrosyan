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
        _castInput.action.performed += OnCastPressed;
    }

    private void OnDisable()
    {
        DisableInput();
        _castInput.action.performed -= OnCastPressed;
    }
    private void OnCastPressed(InputAction.CallbackContext context)
    {
        if (_spellQuickbar.SelectedSpell is null)
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
    }

    public void DisableInput()
    {
        _castInput.action.Disable();
    }
}
