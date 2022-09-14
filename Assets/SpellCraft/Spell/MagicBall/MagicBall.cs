using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class MagicBall : MonoBehaviour
{
    public CollisionUnityEvent Hit;
    [SerializeField] private float _speed; 
    private Rigidbody _rigidbody;

    private int _damage;

    private bool _launched = false;
      
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Init(int damage)
    {
        _damage = damage;
    }

    public void Launch(Vector3 direction)
    {
        if (_launched)
            return;


        var launchDirection = direction.normalized * _speed; 
        _rigidbody.AddForce(launchDirection, ForceMode.Acceleration);

        _launched = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.TryGetComponent<ITakeDamage>(out ITakeDamage target))
        {
            target.TakeDamage(_damage);
            Hit?.Invoke(collision);

        }

        Destroy(gameObject);
    }
}


[Serializable]
public class CollisionUnityEvent : UnityEvent<Collision>
{

}
