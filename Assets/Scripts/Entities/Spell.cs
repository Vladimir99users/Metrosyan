using System;
using UnityEngine;

/// <summary>
/// Базовый класс для заклинаний
/// </summary>
public abstract class Spell : Item
{
    public Core TypeCore { get; protected set; }
    public abstract void Use();
}

