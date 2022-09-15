using UnityEngine;

public class CameraMoveThirdPerson : MonoBehaviour
{

    [SerializeField] private GameObject _target;
    private Vector3 offset;
    void Start()
    {
        offset = transform.position - _target.transform.position;       
    }

    
    void LateUpdate()
    {
        Vector3 desiredPosition = _target.transform.position + offset;
        transform.position = desiredPosition;

    }
}
