using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ISlotNotification))]
public class SlotPresenter : MonoBehaviour
{
    [SerializeField] private Image _slotImage;

    private ISlotNotification _slot;

    private void Awake()
    {
        _slot = GetComponent<ISlotNotification>();

        if (_slot.CurrentItem != null)
        {
            _slotImage.sprite = _slot.CurrentItem.Sprite; 
        }
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
    protected virtual void OnAdded(CraftEntity entity)
    {
        _slotImage.sprite = entity.Sprite;
    }

    protected virtual void OnRemoving(CraftEntity entity)
    {
        _slotImage.sprite = null;
    }
}

