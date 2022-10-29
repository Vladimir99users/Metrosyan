
using UnityEngine;
using UnityEngine.InputSystem;

public class QuestDisplayControls : Menu
{
    [SerializeField] private InputActionReference _openDisplayInput;
    

    private void OnEnable()
    {
        _openDisplayInput.action.Enable();
        _openDisplayInput.action.performed += OnOpenDisplayiPressed;
        
    }

    private void OnDisable()
    {
        _openDisplayInput.action.Disable();
        _openDisplayInput.action.performed -= OnOpenDisplayiPressed;
    }

    private void OnOpenDisplayiPressed(InputAction.CallbackContext context)
    {
        if(IsOpen == false)
            Open();
        else 
            Close();
    }
    public override void Open()
    {
        base.Open();
    }
    public override void Close()
    {
        base.Close();
    }


}
