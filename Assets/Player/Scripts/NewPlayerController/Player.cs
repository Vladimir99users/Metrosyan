using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private InputManadger _input;
    private Movement _movement => GetComponent<Movement>();
    private DirectionMouse _direction => GetComponent<DirectionMouse>();

    void Update()
    {
        _movement.Move(_input.MovementAction.action.ReadValue<Vector2>());
        gameObject.transform.LookAt(_direction.DirectionMouseRotation
            (_input.LookMouseAction.action.ReadValue<Vector2>()));
    }

    
}
