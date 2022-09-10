using UnityEngine;

public class AuraEffect : MonoBehaviour
{
    private Aura _aura;
    private ParticleSystem _particleSystem;

    public void Init(Aura aura, AuraConfig auraConfig)
    {
        _aura = aura;
        _particleSystem = Instantiate(auraConfig.ParticleSystem, transform);
        Enable();
    }

    private void Enable()
    {
        if(_aura is null)
        {
            return;
        }

        _aura.Enabled += OnAuraEnabled;
        _aura.Disabled += OnAuraDisabled;
    }

    private void OnAuraEnabled()
    {
        _particleSystem.Play();
    }

    private void OnAuraDisabled()
    {
        _particleSystem.Stop();
    }

    private void OnEnable()
    {
        Enable();
    }

    private void OnDisable()
    {
        _aura.Enabled -= OnAuraEnabled;
        _aura.Disabled -= OnAuraDisabled;
    }

}
