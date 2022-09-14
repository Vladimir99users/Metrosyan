using UnityEngine;
using UnityEngine.InputSystem;

public class Dash : MonoBehaviour
{
    [SerializeField][Range(0f,150f)] private float dashForce = 10f;
    [SerializeField] private InputActionReference _dashInput;

    [Header("Cooldown")]
    [SerializeField] private float dashCd;
    private float dashCdTimer;
    private Rigidbody _rigidbody  => GetComponent<Rigidbody>();
    private bool _enabled;

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
        _dashInput.action.Enable();
         _dashInput.action.performed += (c) => DashAction();
        _enabled = true;
    }

    public void DisableInput()
    {
        _dashInput.action.Disable();
        _enabled = false;
    }

    private void DashAction()
    {
        Debug.Log("Dash");
        Vector3 forceToApply = (gameObject.transform.forward * dashForce);
        //_rigidbody.MovePosition(forceToApply);
        _rigidbody.velocity = forceToApply ;
    }
}
