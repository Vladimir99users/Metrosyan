using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpellCaster : MonoBehaviour, IInputLisener
{
    [SerializeField] private SpellSight _spellSign;
    [SerializeField] private InputActionReference _castInput;
    [SerializeField] private SpellQuickbar _spellQuickbar;

    private float _reloadTimer;

    public void Cast(Spell spell)
    {
       
          spell.Use(_spellSign.Position, Vector3.zero);
          
       
    }
      
    private void Update()
    {
        if(_reloadTimer > 0f)
        {
            _reloadTimer -= Time.deltaTime;
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
        if (_reloadTimer > 0f)
        {
            return;
        }

        if (_spellQuickbar.SelectedSpell is null)
        {
            return;
        }
        var spell = _spellQuickbar.SelectedSpell;

        switch (spell.CastType)
        {
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
        }

        _reloadTimer = spell.Core.Stats.ReloadTime;
        
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
