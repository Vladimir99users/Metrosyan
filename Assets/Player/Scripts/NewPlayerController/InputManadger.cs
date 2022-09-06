using UnityEngine;
using UnityEngine.InputSystem;
public class InputManadger : MonoBehaviour, IInputLisener
{
    [SerializeField] private GameObject  _controlCreature;
    private Movement _movement => _controlCreature.GetComponent<Movement>();
    private DirectionMouse _direction => _controlCreature.GetComponent<DirectionMouse>();
    [SerializeField] private InputActionReference _movementAction;
    [SerializeField] private InputActionReference _lookMouseAction;

    public void EnableInput()
    {
        _movementAction.action.Enable();
        _lookMouseAction.action.Enable();
    }

    public void DisableInput()
    {
        _movementAction.action.Disable();
        _lookMouseAction.action.Disable();
    }

    private void OnEnable()
    {
        EnableInput();
    }

    private void OnDisable()
    {
        DisableInput();
    }


    private void Update()
    {
        _movement.Move(_movementAction.action.ReadValue<Vector2>());
        _controlCreature.transform.LookAt(_direction.DirectionMouseRotation
            (_lookMouseAction.action.ReadValue<Vector2>()));
    }


}
