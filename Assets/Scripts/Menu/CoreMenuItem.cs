using System;
using UnityEngine;
using UnityEngine.UI;


public class CoreMenuItem : MenuItem<Core>
{
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

