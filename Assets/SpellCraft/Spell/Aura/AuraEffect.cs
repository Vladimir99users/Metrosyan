using UnityEngine;

public class AuraEffect : MonoBehaviour
{
    private Attack _attack;
    private ParticleSystem _particleSystem;
    private bool _enabled;

    public void Init(Attack attack, AuraConfig auraConfig)
    {
        _particleSystem = Instantiate(auraConfig.ParticleSystem, transform);
        _attack = attack;
    }

    public void EnableAura()
    {
        _particleSystem.Play();
        _enabled = true;
    }


    public void DisableEffect()
    {
        _enabled = false;
        _particleSystem.Stop();
    }

    private void Update()
    {
        if(_enabled == false)
        {
            return;
        }

        _attack.Hit();
    }




}
