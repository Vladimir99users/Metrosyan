using UnityEngine;
using UnityEngine.Events;

public class CoreSelector : MonoBehaviour
{
    public UnityEvent CoreSelected;

    [SerializeField] private CoreSlot _coreSlot;
    [SerializeField] private CoreMenu _coreChooseMenu;

    public void ChooseCore()
    {
        _coreChooseMenu.CoreSelected += OnCoreSelected;
        _coreChooseMenu.Open();
    }

    private void OnCoreSelected(Core core)
    {
        _coreSlot.Add(core);
        _coreChooseMenu.CoreSelected -= OnCoreSelected;
        CoreSelected?.Invoke();
    }
}
