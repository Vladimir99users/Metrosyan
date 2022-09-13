using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class QuickbarSlot : MonoBehaviour, IInputLisener
{
    public SpellSlot SpellSlot => _spellSlot;

    public event Action<QuickbarSlot> Selected;
    public event Action<QuickbarSlot> Diselected;

    [SerializeField] private InputActionReference _inputAction;
    [SerializeField] private SpellSlot _spellSlot;
    [SerializeField] private Image _selectImage;

    public bool IsSelected { get; private set; }
    public void Select()
    {
        IsSelected = true;
        _selectImage.enabled = true;
        Selected?.Invoke(this);
    }

    public void Diselect()
    {
        IsSelected = false;
        _selectImage.enabled = false;
        Diselected?.Invoke(this);
    }
    public void EnableInput()
    {
        _inputAction.action.Enable();
    }

    public void DisableInput()
    {
        _inputAction.action.Disable();
    }

    private void OnSelectButton(InputAction.CallbackContext c)
    {
        if (IsSelected)
        {
            Diselect();
        }
        else
        {
            Select();
        }
    }

    private void OnEnable()
    {
        _inputAction.action.performed += OnSelectButton;
        EnableInput();
    }

    private void OnDisable()
    {
        _inputAction.action.performed -= OnSelectButton;
        DisableInput();
        
    }


}
