using UnityEngine;

[CreateAssetMenu(fileName = "AuraConfig", menuName = "Spell/AuraConfig")]
public class AuraConfig : ScriptableObject
{
    [SerializeField] private ParticleSystem _particleSystemPrefab;
    public ParticleSystem ParticleSystem => _particleSystemPrefab;
}