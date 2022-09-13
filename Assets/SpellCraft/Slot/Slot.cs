using System;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Слот для хранения сущности крафта. 
/// Например, слот для крафта
/// </summary>
/// <typeparam name="TItem">Тип хранимый элемент</typeparam>
public abstract class Slot<TItem> : MonoBehaviour, ISlotNotification<TItem>
    where TItem : IStorable
{
    public TItem CurrentItem => _item;

    [SerializeField] private TItem _item;

    public event Action<TItem> Added;

    public event Action<TItem> Removing;

    public virtual void Add(TItem item)
    {
        _item = item;
        Added?.Invoke(_item);
    }

    public virtual void Remove()
    {
        _item = default(TItem);
        Removing?.Invoke(_item);
    }
}

public interface ISlotNotification<TItem>
{
    public TItem CurrentItem { get; }

    public event Action<TItem> Added;
    public event Action<TItem> Removing;
}
