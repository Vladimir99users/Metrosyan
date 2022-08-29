using UnityEngine;
using UnityEngine.InputSystem;
public class InputManadger : MonoBehaviour
{
    [SerializeField] private GameObject  _controlCreature;
    private Movement _movement => _controlCreature.GetComponent<Movement>();
    private DirectionMouse _direction => _controlCreature.GetComponent<DirectionMouse>();
    private KeyBoardInput _keyBoardInput;
    private InputAction _movementAction;
    private InputAction _lookMouseAction;

    private void Awake()
    {
        _keyBoardInput = new KeyBoardInput();
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        _movementAction = _keyBoardInput.KeyBoardContoller.WASD;
        _lookMouseAction = _keyBoardInput.KeyBoardContoller.LookMouse;
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
        _controlCreature.transform.LookAt(_direction.DirectionMouseRotation(_lookMouseAction.ReadValue<Vector2>()));
    }
}
