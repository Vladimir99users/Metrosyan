using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Aura", menuName = "SpellCraft/Aura")]
public class Aura : Spell
{
    public event Action Enabled;
    public event Action Disabled;
    public event Action Hitting;

    private AuraConfig _auraConfig;

    private Attack _auraAttack;

    private bool _enabled;


    public void Init(Attack auraAttack, AuraConfig auraConfig)
    {
        _auraAttack = auraAttack;
        _auraConfig = auraConfig;
    } 

    protected void Enable()
    {
        _enabled = true;
        Enabled?.Invoke();
    }

    protected void Disable()
    {
        _enabled = false;
        Disabled?.Invoke();
    }

    public override void Use(Vector3 castPosition, Vector3 direction, GameObject target)
    {
        var auraEffect = target.AddComponent<AuraEffect>();
        auraEffect.Init(this, _auraConfig);
        Enable();

    }

    private void Update()
    {
        if(_enabled == false)
        {
            return;
        }

        _auraAttack.Hit();
        Hitting?.Invoke();
    }
}
