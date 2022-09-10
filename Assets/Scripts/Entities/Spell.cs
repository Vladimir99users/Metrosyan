using System;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Базовый класс для заклинаний
/// </summary>
public abstract class Spell : Item
{
    public Core TypeCore { get; protected set; }
    public Action<Spell> Used;
    public abstract GameObject SpellGameObject { get; protected set; }

    [SerializeField] protected GameObject _spellPrefab;

    public abstract void Use(Vector3 castPosition = default(Vector3), Vector3 direction = default(Vector3), GameObject target = null);
}
