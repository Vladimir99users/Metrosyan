using System;
using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "GolemCast", menuName = "Spell/GolemCast")]
public class GolemCast : Spell
{
    public Action<Golem> Used;

    private Golem _prefab;
    private Attack _attack;

    private GolemCaster _golemCaster;
    private IEnumerable _startBuffs;

    public void Init(Golem prefab, Attack attack, GolemCaster golemCaster)
    {
        _prefab = prefab;
        _attack = attack;
        _golemCaster = golemCaster;
    }

    public void SetStartBuffs(IEnumerable spells)
    {
        _startBuffs = spells;
    }
    
    public override void Use(Vector3 castPosition, Vector3 direction, GameObject target)
    {
        var golem = _golemCaster.CastAndDisable(_prefab, castPosition, direction);
        golem.Init(_attack, _startBuffs);
        golem.gameObject.SetActive(true);
        Used?.Invoke(golem);
    }
}
