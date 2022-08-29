using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCreature : MonoBehaviour
{
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private bool IsGrounded = false;
    private Vector3 _velocity = new Vector3();
    
    public Vector3 Gravity()
    {
        if(IsGrounded && _velocity.y < 0)
        {
            _velocity.y = transform.position.y;
        } 
          // гравитация delta y = 1/2 * g * t^2;
        _velocity.y += _gravity * Time.deltaTime;  
        return _velocity * Time.deltaTime;  
    }
}
