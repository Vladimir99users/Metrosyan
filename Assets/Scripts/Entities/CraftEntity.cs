
using UnityEngine;

public abstract class CraftEntity : ScriptableObject
{
    [SerializeField] private Sprite _sprite;                                                             
    [SerializeField] private EntityStats _stats;

    public EntityStats Stats => _stats;
    public Sprite Sprite => _sprite;
}
