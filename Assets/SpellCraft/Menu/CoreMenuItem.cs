using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CoreMenuItem : SelectableItem<Core>
{
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnSelect);

        SetImage();
    }


    protected void SetImage()
    {
        if (_item is null)
            return;

        _image.sprite = _item.Sprite;
    }

#if UNITY_EDITOR
    [ContextMenu("SetImageInspector")]
    private void SetImageInspector()
    {
        if (_item is null)
            return;

        _image.sprite = _item.Sprite;
    }
#endif
}

