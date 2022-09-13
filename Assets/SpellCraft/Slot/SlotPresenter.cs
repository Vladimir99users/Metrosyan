using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ISlotNotification<Core>))]
public abstract class SlotPresenter<TItem> : MonoBehaviour
    where TItem : IStorable
{
    [SerializeField] protected Image _slotImage;

    private ISlotNotification<TItem> _slot;

    protected virtual void OnAwake()
    {
        _slot = GetComponent<ISlotNotification<TItem>>();

        if (_slot.CurrentItem != null)
        {
            _slotImage.sprite = _slot.CurrentItem.Sprite;
        }
    }

    private void Awake()
    {
        OnAwake();
    }

    private void OnEnable()
    {
        _slot.Added += OnAdded;
        _slot.Removing += OnRemoving;
    }

    private void OnDisable()
    {
        _slot.Added -= OnAdded;
        _slot.Removing -= OnRemoving;
    }
    protected virtual void OnAdded(TItem entity)
    {
        _slotImage.sprite = entity.Sprite;
    }

    protected virtual void OnRemoving(TItem entity)
    {
        _slotImage.sprite = null;
    }
}
