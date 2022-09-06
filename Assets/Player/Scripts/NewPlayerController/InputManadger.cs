using UnityEngine;
using UnityEngine.InputSystem;
public class InputManadger : MonoBehaviour
{  
    [SerializeField] private InputActionReference _movementAction;
    [SerializeField] private InputActionReference _lookMouseAction;

    public InputActionReference MovementAction => _movementAction;
    public InputActionReference LookMouseAction => _lookMouseAction;

    private void OnEnable()
    {
        EnableInputActons();
    }

    private void EnableInputActons()
    {
        _movementAction.action.Enable();
        _lookMouseAction.action.Enable();

    } 

    private void OnDisable()
    {
        _movementAction.action.Disable();
        _lookMouseAction.action.Disable();
    }
}
