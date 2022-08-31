using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    private Rigidbody _rigidbody  => GetComponent<Rigidbody>();

    public Rigidbody Rigidbody
    {
        get {return _rigidbody ;}
        set {value = _rigidbody ;}
    }

    [SerializeField][Range(0f,30f)] private float _speed = 10f;
    public virtual void Move(Vector2 input)
    {
        var newMove = new Vector3 (input.x,0f ,input.y).normalized;
        _rigidbody.MovePosition(_rigidbody.position + (newMove * _speed * Time.deltaTime));
    }
}
