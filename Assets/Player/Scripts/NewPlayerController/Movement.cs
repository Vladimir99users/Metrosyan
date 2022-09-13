using UnityEngine.InputSystem;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour,IInputLisener
{
    [SerializeField][Range(0f,30f)] private float _speed = 10f;
    [SerializeField] private InputActionReference _movementInput;

    private Vector3 _moveVector  = Vector3.zero;
    private bool _enabled;
    private Rigidbody _rigidbody  => GetComponent<Rigidbody>();


    private void OnEnable()
    {
        EnableInput();
    }

    private void OnDisable()
    {
        DisableInput();
    }
    public void EnableInput()
    {
        _movementInput.action.Enable();
        _enabled = true;
    }

    public void DisableInput()
    {
        _movementInput.action.Disable();
        _enabled = false;
    }

    private void Update()
    {
        if(_enabled == false)
        {
            return;
        }
        _moveVector = _movementInput.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        if (_enabled == false)
        {
            return;
        }

        Move(_moveVector);
    }

    public virtual void Move(Vector2 input)
    {
        
        if(input.x == 0 && input.y == 0) 
        {
            AnimatorCreature._onStateCreature?.Invoke(StateCreature.Idle);
            return;
        }
        var newMove = new Vector3 (input.x, 0f,input.y).normalized;
        AnimatorCreature._onStateCreature?.Invoke(StateCreature.Walking);
        _rigidbody.MovePosition(_rigidbody.position + (newMove * _speed * Time.deltaTime));
    }
}
