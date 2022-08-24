using System;
using UnityEngine;
using UnityEngine.Events;

public abstract class Slot<TItem> : MonoBehaviour, ISlotNotification
    where TItem : CraftEntity
{
    CraftEntity ISlotNotification.CurrentItem => _item;
    public TItem Item => _item;
    
    [SerializeField] private TItem _item;

    public event Action<CraftEntity> Added;
    public event Action<CraftEntity> Removing;

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
    public CraftEntity CurrentItem { get; }

    public event Action<CraftEntity> Added;
    public event Action<CraftEntity> Removing;
}
