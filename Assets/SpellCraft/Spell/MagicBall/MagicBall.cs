using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MagicBall : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody _rigidbody;

    private bool _launched = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Launch(Vector3 direction)
    {
        if (_launched)
            return;


        var launchDirection = direction.normalized * _speed; 
        _rigidbody.AddForce(launchDirection, ForceMode.Acceleration);

        _launched = true;
    }
}
