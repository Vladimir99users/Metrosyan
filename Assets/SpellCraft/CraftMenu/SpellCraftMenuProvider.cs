using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SpellCraftMenuProvider : MonoBehaviour
{
    public UnityEvent OnSpellAddSuccess;
    public UnityEvent OnSpellAddFail;

    [SerializeField] private SpellCraftMenu _craftMenu;
    [SerializeField] private SpellQuickbar _spellQuickbar;

    [SerializeField] private Button _addButton;

    private Spell _craftedSpell;
    
    private void Awake()
    {
        _craftMenu.SpellCrafted.AddListener(OnSpellCrafted);
        _addButton.onClick.AddListener(OnAddButton);
    }

    private void OnAddButton()
    {
        if (_craftedSpell == null)
        {
            OnSpellAddFail?.Invoke();
            return;
        }

        _spellQuickbar.AddSpell(_craftedSpell);
        OnSpellAddSuccess?.Invoke();
    }

    private void OnSpellCrafted(Spell craftedSpell)
    {
        _craftedSpell = craftedSpell;
    }

}
