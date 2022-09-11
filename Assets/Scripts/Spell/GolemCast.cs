using UnityEngine;

[CreateAssetMenu(fileName = "GolemCast", menuName = "Spell/GolemCast")]
public class GolemCast : Spell
{
    private Golem _prefab;
    private Attack _attack;

    private GolemCaster _golemCaster;

    public void Init(Golem prefab, Attack attack, GolemCaster golemCaster)
    {
        _prefab = prefab;
        _attack = attack;
        _golemCaster = golemCaster;
    }
    
    public override void Use(Vector3 castPosition, Vector3 direction)
    {
        var golem = _golemCaster.CastAndDisable(_prefab, castPosition, direction);
        golem.Init(_attack);
        golem.gameObject.SetActive(true);
    }

    public override void Use(Vector3 castPosition, Vector3 direction, GameObject target)
    {
        throw new System.NotImplementedException();
    }
}
