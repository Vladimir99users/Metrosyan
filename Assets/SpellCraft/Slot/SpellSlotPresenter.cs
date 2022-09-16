using System;
using UnityEngine;
using UnityEngine.UI;

public class SpellSlotPresenter : SlotPresenter<Spell>
{
    protected override void OnAdded(Spell entity)
    {
        base.OnAdded(entity);
        _slotImage.color = entity.Core.Color;

    }
}



