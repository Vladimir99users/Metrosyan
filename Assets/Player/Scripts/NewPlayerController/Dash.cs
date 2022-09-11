using UnityEngine.InputSystem;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Dash : MonoBehaviour, IInputLisener
{
    [SerializeField] private InputActionReference _dashAction;
    [SerializeField][Range(0,5f)] private float _dashTime = 2.5f;
    [SerializeField][Range(0,5f)] private float _dashingTime = 0.2f;
    [SerializeField][Range(5,50f)] private float _dashingPower = 24f;
    private Rigidbody _rigidbody;

    private void Awake()
    {   
        _dashAction.action.performed += (c) =>
        {   
            DashCreature();
        };
    }

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
        _dashAction.action.Enable();
    }

    public void DisableInput()
    {
        _dashAction.action.Disable();
    }

    private void DashCreature()
    {
        Debug.Log("Dash");
    }
}
