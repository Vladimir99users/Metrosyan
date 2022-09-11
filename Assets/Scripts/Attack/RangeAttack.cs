using System;
using System.Collections;
using UnityEngine;

public class RangeAttack : Attack
{ 
    private Projectale _projectale;

    ///<param name="projectale">Снаряд, которым будет производиться атака</param>
    public RangeAttack(Projectale projectale)
    {
        _projectale = projectale;
    }
    
    public override void Hit()
    {
        Debug.Log("I shoot " + _projectale.Type + " " + _projectale.Damage);
    }
}
