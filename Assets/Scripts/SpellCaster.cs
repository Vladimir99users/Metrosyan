using UnityEngine;
using UnityEngine.InputSystem;

public class SpellCaster : MonoBehaviour
{
    [SerializeField] private SpellSign _spellSign;
    [SerializeField] private InputActionReference _castInput;
    [SerializeField] private SpellSlot _spellSlot;

    private void OnEnable()
    {
        _castInput.action.Enable();
        _castInput.action.performed += OnCastPressed;
    }


    public void Cast(Spell spell)
    {
        Debug.Log($"Кастую в точку {_spellSign.Position} заклинание {spell.name}");
        spell.Use(_spellSign.Position, Vector3.zero);
    }

    private void OnCastPressed(InputAction.CallbackContext context)
    {
        if (_spellSlot.CurrentItem is null)
            return;

        Cast(_spellSlot.CurrentItem);
    }


}
