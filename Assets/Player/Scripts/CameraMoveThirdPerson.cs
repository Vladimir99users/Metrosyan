using UnityEngine;

sealed class CameraMoveThirdPerson : MonoBehaviour
{

    [SerializeField] private GameObject _target;
    private Vector3 offset;

    [SerializeField] [Range(-25,25)] private float _xOffset = 0;
    [SerializeField] [Range(-25,25)] private float _yOffset = 0;
    [SerializeField] [Range(-25,25)] private float _zOffset = 0;

    [SerializeField] [Range(-180,180)] private float _angelX = 0;
    [SerializeField] [Range(-180,180)] private float _angelY = 0;
    [SerializeField] [Range(-180,180)] private float _angelZ = 0;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - _target.transform.position;

        transform.position = new Vector3
            (_target.transform.position.x + _xOffset, _target.transform.position.y + _yOffset,_target.transform.position.z + _zOffset);
    }

    
    void LateUpdate()
    {
        Vector3 desiredPosition = _target.transform.position + offset;
        transform.position = new Vector3(desiredPosition.x + _xOffset,
        desiredPosition.y + _yOffset, desiredPosition.z + _zOffset);

        transform.localEulerAngles = new Vector3(_angelX,_angelY,_angelZ);
    }
}
