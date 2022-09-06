using UnityEngine;

public abstract class CraftEntity : Item
{                                                         
    [SerializeField] private EntityStats _stats;
    [SerializeField] private Color _color;

    public Color Color => _color;
    public EntityStats Stats => _stats;
}

