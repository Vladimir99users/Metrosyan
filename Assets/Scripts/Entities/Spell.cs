using System;
using UnityEngine;

/// <summary>
/// Базовый класс для заклинаний
/// </summary>
public abstract class Spell : Item
{
    public Core TypeCore { get; protected set; }
    [SerializeField] protected GameObject _spellPrefab;

    public abstract void Use(Vector3 castPosition, Vector3 direction);
}

