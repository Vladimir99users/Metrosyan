using System;
using UnityEngine;
using UnityEngine.Events;

public abstract class Slot<TItem> : MonoBehaviour, ISlotNotification
    where TItem : Entity
{
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
    public event Action<Entity> Added;
    public event Action<Entity> Removing;
}
