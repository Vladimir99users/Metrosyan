using System.Collections.Generic;
using UnityEngine;

public class GolemCraftMenu : Menu
{
    [SerializeField] private CoreSlot _typeSlot;
    [SerializeField] private CoreSlot _extraSlot;
    [SerializeField] private SpellSlot _spellSlot;
    [SerializeField] private GolemFactory _golemFactory;
    [SerializeField] private CoreMenu _menu;

    private AttackFactoryBase _attackFactory = new RangeAttackFactory();

    public void Craft()
    {
        if (_typeSlot.CurrentItem is null)
            return;
        
        Spell golem = _golemFactory.Get(_typeSlot.CurrentItem);

        _spellSlot.Add(golem);
    }

    public override void Open()
    {
        gameObject.SetActive(true);
        base.Open();
    }

    public override void Close()
    {
        gameObject.SetActive(false);
        base.Close();
    }
}
