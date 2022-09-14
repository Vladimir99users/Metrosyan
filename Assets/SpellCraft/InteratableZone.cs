using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(SphereCollider))]
public class InteratableZone : MonoBehaviour
{
    public UnityEvent InteractedButtonPressed;
    public UnityEvent ZoneEnter;
    public UnityEvent ZoneExit;

    [SerializeField] private InputActionReference _interactionAction;
    [SerializeField] private LayerMask _playerLayer;

    private bool _interactionAvailabe = false;

    private void OnEnable()
    {
        _interactionAction.action.performed += OnInteraction;
        if(_interactionAction.action.enabled == false)
        {
            _interactionAction.action.Enable();
        }
    }

    private void OnDisable()
    {
        _interactionAction.action.performed -= OnInteraction;
    }

    private void OnInteraction(InputAction.CallbackContext c)
    {
        if (_interactionAvailabe)
        {
            InteractedButtonPressed?.Invoke();

        }
    }

    private void OnTriggerEnter(Collider colision)
    {
        if(colision.gameObject.TryGetComponent<Player>(out Player player) == false)
        {
            return;
        }

        _interactionAvailabe = true;
        ZoneEnter?.Invoke();
    }

    public void OnTriggerExit(Collider colision)
    {
        if (colision.gameObject.TryGetComponent<Player>(out Player player) == false)
        {
            return;
        }

        _interactionAvailabe = false;
        ZoneExit?.Invoke();
    }
}
