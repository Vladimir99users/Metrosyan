using System;
using UnityEditor;
using UnityEngine;

[Serializable]
public class EntityStats 
{
    [SerializeField] private float _damage;
    [SerializeField] private CoreType _type;
    [SerializeField] private string _name;

    public float Damage => _damage;
    public CoreType Type => _type;
    public string Name => _name;
    
}
