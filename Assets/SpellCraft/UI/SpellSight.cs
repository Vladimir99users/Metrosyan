using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(SpriteRenderer))]
public class SpellSight : MonoBehaviour, IInputLisener
{
    public Vector3 Position => transform.position;

    [SerializeField] private InputActionReference _cursorInput;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField][Range(0.01f, 1f)] private float _groundOffset;
    [SerializeField] private LayerMask _groundMask;

    private Camera _camera;

    private bool _enabled = false;


    public void EnableInput()
    {
        _cursorInput.action.Enable();
    }

    public void DisableInput()
    {
        _cursorInput.action.Disable();
    }

    

    private void LateUpdate()
    {
        if (_enabled == false)
        {
            return;
        }

        Vector3 mousePosition = _cursorInput.action.ReadValue<Vector2>();

        if (TryGetSignPosition(mousePosition, out Vector3 signPosition))
        {
            signPosition.y += _groundOffset;
            Move(signPosition);
        }
    }

    private bool TryGetSignPosition(Vector3 mousePosition, out Vector3 signPosition)
    {
        signPosition = Vector3.zero;

        Ray ray = _camera.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _groundMask))
        {
            signPosition = hit.point;
            return true;
        }

        return false;
    }

    private void Move(Vector3 position)
    {
        transform.position = position;
    }

    private void ChangeColor(Color color)
    {
        _spriteRenderer.color = color;
    }


    public void Show()
    {
        _spriteRenderer.enabled = true;
    }

    public void Hide()
    {
        _spriteRenderer.enabled = false;
    }



    private void Awake()
    {
        _camera = Camera.main;
    }

    private void OnEnable()
    {
        _enabled = true;
        EnableInput();
        Show();
    }

    private void OnDisable()
    {
        _enabled = false;
        DisableInput();
        Hide();
    }



}
