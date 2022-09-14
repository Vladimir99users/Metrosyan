using UnityEngine;

public class FactoryPrefabs<T> : ScriptableObject
{
    [SerializeField] protected T _firePrefab;
    [SerializeField] protected T _waterPrefab;
    [SerializeField] protected T _earthPrefab;
    [SerializeField] protected T _airPrefab;
    [SerializeField] protected T _darkPrefab;
    [SerializeField] protected T _lightPrefab;

    public T GetPrefab(Core core) =>
       core.Stats.Type switch
       {
           CoreType.Fire => _firePrefab,
           CoreType.Water => _waterPrefab,
           CoreType.Earth => _earthPrefab,
           CoreType.Air => _airPrefab,
           CoreType.Dark => _darkPrefab,
           CoreType.Light => _lightPrefab,
       };
}