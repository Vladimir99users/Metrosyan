using System;
using UnityEngine;
using UnityEngine.Events;

public abstract class Slot<TItem> : MonoBehaviour, ISlotNotification
    where TItem : Entity
{
    Entity ISlotNotification.CurrentItem => _item;
    public TItem Item => _item;
    
    [SerializeField] private TItem _item;

    public event Action<Entity> Added;
    public event Action<Entity> Removing;

    public virtual void Add(TItem item)
    {
        _item = item;
        Added?.Invoke(_item);
    }

    public virtual void Remove()
    {
        _item = null;
        Removing?.Invoke(null);
    }
}

public interface ISlotNotification
{
    public Entity CurrentItem { get; }

    public event Action<Entity> Added;
    public event Action<Entity> Removing;
}