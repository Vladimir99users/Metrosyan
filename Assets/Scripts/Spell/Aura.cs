using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Aura", menuName = "SpellCraft/Aura")]
public class Aura : Spell
{
    public event Action Enabled;
    public event Action Disabled;

    private AuraConfig _auraConfig;

    private Attack _auraAttack;


    public void Init(Attack auraAttack, AuraConfig auraConfig)
    {
        _auraAttack = auraAttack;
        _auraConfig = auraConfig;
    } 

    public override void Use(Vector3 castPosition, Vector3 direction, GameObject target)
    {
        var auraEffect = target.AddComponent<AuraEffect>();
        auraEffect.Init(_auraAttack, _auraConfig);
        auraEffect.EnableAura();
    }

}
