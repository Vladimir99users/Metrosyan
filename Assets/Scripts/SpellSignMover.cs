using UnityEngine;
using UnityEngine.InputSystem;

//Ќарисовать прицел дл€ каста заклинани€
public class SpellSignMover : MonoBehaviour
{

    //Ќарисовать место куда будет закастовано заклинание
    [SerializeField] private InputActionReference _cursorInput;
    [SerializeField] private SpellSign _sign;

    private Camera _camera;
    private Vector2 _mouseLastPosition = Vector2.zero;

    private bool _enabled = false;

    private void Awake()
    {
        _mouseLastPosition = _cursorInput.action.ReadValue<Vector2>();
        _camera = Camera.main;

        Enable();
    }

    public void Enable()
    {
        _enabled = true;
        _cursorInput.action.Enable();
        _sign.Show();
    }

    public void Disable()
    {
        _enabled = false;
        _cursorInput.action.Disable();
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
            return true;
        }

        return false;
    }

    

   
    
  
}
