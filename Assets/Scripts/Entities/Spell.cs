using System;
using UnityEngine;

/// <summary>
/// Базовый класс для заклинаний
/// </summary>
public abstract class Spell : ScriptableObject, IStorable
{
    public Action<Spell> Used;
    Sprite IStorable.Sprite => _sprite;
    [SerializeField] private Sprite _sprite;

    public abstract void Use(Vector3 castPosition, Vector3 direction);
    public abstract void Use(Vector3 castPosition, Vector3 direction,GameObject target);
}

