using UnityEngine;
using UnityEngine.InputSystem;

public class SpellSignMover : MonoBehaviour, IInputLisener
{

    [SerializeField] private InputActionReference _cursorInput;
    [SerializeField] private SpellSign _sign;

    private Camera _camera;
    private Vector2 _mouseLastPosition = Vector2.zero;

    private bool _enabled = false;


    public void EnableInput()
    {
        _cursorInput.action.Enable();
    }

    public void DisableInput()
    {
        _cursorInput.action.Disable();
    }

    private void Awake()
    {
        _mouseLastPosition = _cursorInput.action.ReadValue<Vector2>();
        _camera = Camera.main;

    }

    private void OnEnable()
    {
        _enabled = true;
        EnableInput();
        _sign.Show();
    }

    private void OnDisable()
    {
        _enabled = false;
        DisableInput();
        _sign.Hide();
    }

    private void LateUpdate()
    {
        if (_enabled == false)
        {
            return;
        }
        var mousePosition = _cursorInput.action.ReadValue<Vector2>();
        if (mousePosition == _mouseLastPosition)
        {
            return;
        }
        if(TryGetSignPosition(mousePosition, out Vector3 signPosition))
        {
            _sign.Move(signPosition);    
            _mouseLastPosition = mousePosition;
        }
    }

    private bool TryGetSignPosition(Vector3 mousePosition, out Vector3 signPosition)
    {
        signPosition = Vector3.zero;
    
        Ray ray = _camera.ScreenPointToRay(mousePosition);
       
        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            signPosition = hit.point;
             Debug.DrawRay(mousePosition,signPosition,Color.blue);
            return true;
        }

        return false;
    }

}
