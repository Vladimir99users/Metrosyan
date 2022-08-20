using System;
using System.Collections.Generic;
using UnityEngine;

public class CoreMenu : Menu
{
    [SerializeField] private List<CoreMenuItem> _menuItems;
    [SerializeField] private CoreMenuItem _selectedItem;

    public Core SelectedCore => _selectedItem?.Item;

    public event Action<Core> CoreSelected;

    protected override void OnAwake()
    {
        base.OnAwake();

        foreach(var item in _menuItems)
        {
            item.Init(OnItemSelected);
        }
    }

    private void OnItemSelected(CoreMenuItem coreMenuItem)
    {
        _selectedItem = coreMenuItem;
        CoreSelected?.Invoke(_selectedItem.Item);
        Close();
    }

}