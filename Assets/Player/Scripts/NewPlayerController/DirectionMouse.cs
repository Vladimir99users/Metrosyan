using UnityEngine.InputSystem;
using UnityEngine;

public class DirectionMouse : MonoBehaviour, IInputLisener
{
    [SerializeField] private InputActionReference _mouseInput;

    private Transform _targetTransform;
    private Camera _mainCamera;

    private bool _inputEnabled;

    private Plane _groundPlane = new Plane(Vector3.up,Vector3.zero);

    private Vector3 _lookVector = Vector3.zero;


    private void Awake()
    {
        _mainCamera = Camera.main;
        _targetTransform = GetComponent<Transform>();
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
        _mouseInput.action.Enable();
        _inputEnabled = true;
    }

    public void DisableInput()
    {
        _mouseInput.action.Disable();
        _inputEnabled = false;
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
        if(_inputEnabled == false)
        {
            return;
        }

        _lookVector = _mouseInput.action.ReadValue<Vector2>(); 
    }

    private void FixedUpdate()
    {
        if (_inputEnabled == false)
        {
            return;
        }

        _targetTransform.LookAt(GetDirectionMouseRotation(_lookVector));
    }

}
