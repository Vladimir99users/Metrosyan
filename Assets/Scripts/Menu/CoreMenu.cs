using System;
using System.Collections.Generic;
using UnityEngine;

public class CoreMenu : Menu
{
    [SerializeField] private CoreMenuItem[] _menuItems;
    [SerializeField] private CoreMenuItem _selectedItem;

    public Core SelectedCore => _selectedItem?.Item;

    public event Action<Core> CoreSelected;

    protected override void OnAwake()
    {
        base.OnAwake();

        foreach (var item in _menuItems)
        {
            item.Init(OnItemSelected);
        }
    }


    private void OnItemSelected(MenuItem<Core> coreMenuItem)
    {
        _selectedItem = coreMenuItem as CoreMenuItem;
        CoreSelected?.Invoke(_selectedItem.Item);
        Close();
    }


    [ContextMenu("FindAllMenuItems")]
    protected void FindAllMenuItems()
    {
        _menuItems = GetComponentsInChildren<CoreMenuItem>();
    }

}