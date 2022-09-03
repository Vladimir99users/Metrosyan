using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class QuickbarSlot : MonoBehaviour
{
    [SerializeField] private InputActionReference _inputAction;
    [SerializeField] private SpellSlot _spellSlot;
    [SerializeField] private Image _selectImage;
    public SpellSlot SpellSlot => _spellSlot;

    public event Action<QuickbarSlot> Selected;
    public event Action<QuickbarSlot> Diselected;

    public void Select()
    {
        _selectImage.enabled = true;
        Selected?.Invoke(this);
    }

    public void Diselect()
    {
        _selectImage.enabled = false;
        Diselected?.Invoke(this);
    }

    private void OnSelectButton(InputAction.CallbackContext c)
    {
        Select();
    }

    private void OnEnable()
    {
        _inputAction.action.performed += OnSelectButton;
        _inputAction.action.Enable();
    }

    private void OnDisable()
    {
        _inputAction.action.performed -= OnSelectButton;
        _inputAction.action.Disable();
    }



}
