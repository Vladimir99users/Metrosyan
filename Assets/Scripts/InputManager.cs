using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Vector3 MousePosition { get; private set; } = Vector3.zero;

    private void Update()
    {
        MousePosition = Input.mousePosition;
    }
}