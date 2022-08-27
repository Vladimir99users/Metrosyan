using UnityEngine;

public abstract class CraftEntity : Item
{                                                         
    [SerializeField] private EntityStats _stats;

    public EntityStats Stats => _stats;
}

