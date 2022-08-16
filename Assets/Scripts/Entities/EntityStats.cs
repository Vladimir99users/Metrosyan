using System;
using UnityEditor;
using UnityEngine;

[Serializable]
public class EntityStats 
{
    [SerializeField] private float _damage;
    [SerializeField] private ElementType _type;
    [SerializeField] private string _name;

    public float Damage => _damage;
    public ElementType Type => _type;
    public string Name => _name;
    
}
