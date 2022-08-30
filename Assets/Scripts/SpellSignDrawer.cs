using UnityEngine;

//Ќарисовать прицел дл€ каста заклинани€
public class SpellSignDrawer : MonoBehaviour
{

    //Ќарисовать место куда будет закастовано заклинание
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private SpellSign _sign;

    private Camera _camera;
    private Vector3 _mouseLastPosition = Vector3.zero;

    private bool _enabled = false;

    private void Awake()
    {
        _mouseLastPosition = _inputManager.MousePosition;
        _camera = Camera.main;

        Enable();
    }

    public void Enable()
    {
        _enabled = true;
    }

    public void Disable()
    {
        _enabled = false;
    }

    private void LateUpdate()
    {
        if (_enabled == false)
        {
            return;
        }
        var mousePosition = _inputManager.MousePosition;

        if(mousePosition == _mouseLastPosition)
        {
            return;
        }

        if(TryGetSignPosition(mousePosition, out Vector3 signPosition))
        {
            _sign.Move(signPosition);    
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
