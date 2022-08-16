
using UnityEngine;

public abstract class Entity : ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private EntityStats _stats;

    public Sprite Sprite => _sprite;
    public EntityStats Stats => _stats;

}
