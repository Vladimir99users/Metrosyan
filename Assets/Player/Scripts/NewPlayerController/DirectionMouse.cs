using UnityEngine.InputSystem;
using UnityEngine;

public class DirectionMouse : MonoBehaviour, IInputLisener
{
    [SerializeField] private InputActionReference _lookMouseAction;
    private bool _enabled;
    private  Plane _groundPlane = new Plane(Vector3.up,Vector3.zero);
    private Vector3 _lookVector = Vector3.zero;
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }
    public Vector3 GetDirectionMouseRotation(Vector3 mouse)
    {
        Ray cameraRay = _mainCamera.ScreenPointToRay(mouse);
        if(_groundPlane.Raycast(cameraRay,out float rayLenght))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLenght);
            return new Vector3(pointToLook.x,transform.position.y,pointToLook.z);
          
        }
        return new Vector3();
    }

    public void EnableInput()
    {
        _lookMouseAction.action.Enable();
        _enabled = true;
    }

    public void DisableInput()
    {
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
        _lookVector = _lookMouseAction.action.ReadValue<Vector2>(); 
    }

    private void FixedUpdate()
    {
        if (_enabled == false)
        {
            return;
        }
        gameObject.transform.LookAt(GetDirectionMouseRotation(_lookVector));
    }

}
