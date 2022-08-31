using UnityEngine;
using UnityEngine.InputSystem;
public class InputManadger : MonoBehaviour
{
    [SerializeField] private GameObject  _controlCreature;
    private Movement _movement => _controlCreature.GetComponent<Movement>();
    private DirectionMouse _direction => _controlCreature.GetComponent<DirectionMouse>();
    private InputAction _movementAction;
    private InputAction _lookMouseAction;

    [SerializeField] private Input _keyBoardInput;
    private void Awake()
    {
        _keyBoardInput = new Input();
        //Cursor.visible = false;
       // EnableInputActons();
    }

    private void OnEnable()
    {
        Debug.Log("Enable");
        _movementAction = _keyBoardInput.Keyboard.Movement;
        _lookMouseAction = _keyBoardInput.Keyboard.Cursor;
        EnableInputActons();
    }

    private void EnableInputActons()
    {
        _movementAction.Enable();
        _lookMouseAction.Enable();
        SubscribingActionToEvent();
    }

    private void SubscribingActionToEvent()
    {

    }

    private void OnDisable()
    {
        _movementAction.Disable();
        _lookMouseAction.Disable();
    }


    private void Update()
    {
        _movement.Move(_movementAction.ReadValue<Vector2>());
        _controlCreature.transform.LookAt(_direction.DirectionMouseRotation
            (_lookMouseAction.ReadValue<Vector2>()));
        Debug.Log(_lookMouseAction.ReadValue<Vector2>());
    }
}
