public class SpellSlotPresenter : SlotPresenter<Spell>
{
    protected override void OnAdded(Spell entity)
    {
        _slotImage.color = entity.TypeCore.Color;

        base.OnAdded(entity);

    }
}

