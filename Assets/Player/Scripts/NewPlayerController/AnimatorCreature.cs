using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorCreature : MonoBehaviour
{
   private CreatureHealth _health => GetComponent<CreatureHealth>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_health.IsDie) Debug.Log("I'am Die animation");
    }
}
