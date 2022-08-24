using System;
using System.Collections;
using UnityEngine;

public class RangeAttack : IAttack
{ 

    private Projectale _projectale;

    public RangeAttack(Projectale projectale)
    {
        _projectale = projectale;
    }

    public void Hit()
    {
        Debug.Log("I shoot " + _projectale.Type + " " + _projectale.Damage);
    }
}
