using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CoreMenuItem : MenuItem<Core>
{
    private Button button;

    private Action<CoreMenuItem> _selected;

    public void Init(Action<CoreMenuItem> onSelect)
    {
        _selected = onSelect;
    }

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);

        _image.sprite = _item.Sprite; 
    }

    private void OnButtonClick()
    {
        _selected?.Invoke(this);
    }
}

