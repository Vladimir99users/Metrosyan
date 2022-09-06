using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private IInputLisener _movementAction => GetComponent<Movement>();
    [SerializeField] private IInputLisener _lookMouseAction => GetComponent<DirectionMouse>();

    public void DisableAllAction()
    {
        _movementAction.DisableInput();
        _lookMouseAction.DisableInput();
    }

    public void EnableAllAction()
    {
        _movementAction.EnableInput();
        _lookMouseAction.EnableInput();
    }

}
