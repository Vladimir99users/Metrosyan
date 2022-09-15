using System;
using UnityEngine;
using UnityEngine.UI;

public class SpellSlotPresenter : SlotPresenter<Spell>
{
    [SerializeField] private Image _reloadImage;
    protected override void OnAdded(Spell entity)
    {
        base.OnAdded(entity);
    }
}



