using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class MenuItem<TContent> : MonoBehaviour
    where TContent : CraftEntity
{
    public TContent Item => _item;

    private Action<MenuItem<TContent>> _selected;
    private Button button;

    [SerializeField] protected Image _image;
    [SerializeField] protected TContent _item;

    public void Init(Action<MenuItem<TContent>> onSelect)
    {
        _selected = onSelect;
    }

    protected virtual void OnAwake() 
    {
        SetImage();

        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    protected virtual void OnButtonClick()
    {
        _selected?.Invoke(this);
    }

    private void Awake()
    {
        OnAwake();
    }


    protected void SetImage()
    {
        if (_item is null)
            return;

        _image.sprite = _item.Sprite;
    }
}

