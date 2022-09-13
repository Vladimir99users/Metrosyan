using System;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Базовый класс для заклинаний
/// </summary>
public abstract class Spell : ScriptableObject, IStorable
{
    public Action<Spell> Used;
    Sprite IStorable.Sprite => _sprite;
    [SerializeField] private Sprite _sprite;

    public abstract void Use(Vector3 castPosition = default(Vector3), Vector3 direction = default(Vector3), GameObject target = null);
}
