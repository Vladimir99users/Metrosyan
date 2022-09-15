using System;
using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "GolemCast", menuName = "Spell/GolemCast")]
public class GolemCast : Spell
{
    private Golem _prefab;
    private Attack _attack;

    private IEnumerable _startBuffs;

    public void Init(Golem prefab, Attack attack, Core core)
    {
        _prefab = prefab;
        _attack = attack;
        _core = core;
    }

    public void SetStartBuffs(IEnumerable spells)
    {
        _startBuffs = spells;
    }
    
    public override void Use(Vector3 castPosition, Vector3 direction, GameObject target)
    {
        var golem = GameObject.Instantiate(_prefab, castPosition, Quaternion.Euler(direction));
        golem.Init(_attack, _startBuffs);
    }
}
