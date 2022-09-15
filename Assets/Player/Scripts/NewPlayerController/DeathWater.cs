using UnityEngine;
using System;

public class DeathWater : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<ITakeDamage>(out ITakeDamage pidr))
        {
            pidr.TakeDamage(Int32.MaxValue);
        }
    }
}
