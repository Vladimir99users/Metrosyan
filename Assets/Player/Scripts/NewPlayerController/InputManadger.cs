using UnityEngine;
using UnityEngine.InputSystem;
public class InputManadger : MonoBehaviour, IInputLisener
{
    [SerializeField] private GameObject  _controlCreature;
    private Movement _movement => _controlCreature.GetComponent<Movement>();
    private DirectionMouse _direction => _controlCreature.GetComponent<DirectionMouse>();
    [SerializeField] private InputActionReference _movementAction;
    [SerializeField] private InputActionReference _lookMouseAction;

    private Vector2 _movementVector = Vector2.zero;
    private Vector2 _lookVector = Vector2.zero;

    private bool _enabled = false;
    public void EnableInput()
    {
        _movementAction.action.Enable();
        _lookMouseAction.action.Enable();
        _enabled = true;
    }

    public void DisableInput()
    {
        _movementAction.action.Disable();
        _lookMouseAction.action.Disable();
        _enabled = false;
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
        if(_enabled == false)
        {
            return;
        }
        _movementVector = _movementAction.action.ReadValue<Vector2>();
        _lookVector = _lookMouseAction.action.ReadValue<Vector2>(); 
    }

    private void FixedUpdate()
    {
        if (_enabled == false)
        {
            return;
        }
        _movement.Move(_movementVector);
        _controlCreature.transform.LookAt(_direction.GetDirectionMouseRotation(_lookVector));
    }


}
