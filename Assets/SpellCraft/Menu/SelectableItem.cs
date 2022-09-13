using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

//
public abstract class SelectableItem<TContent> : MonoBehaviour
{
    public TContent Item => _item;

    protected Action<SelectableItem<TContent>> _selected;

    [SerializeField] protected Image _image;
    [SerializeField] protected TContent _item;

    public void Init(Action<SelectableItem<TContent>> onSelect)
    {
        _selected = onSelect;
    }

    protected virtual void OnSelect()
    {
        _selected?.Invoke(this);
    }



}

