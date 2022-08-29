public class SpellSlotPresenter : SlotPresenter<Spell>
{
    protected override void OnAdded(Spell entity)
    {
        CoreColorFactory colorFactory = new CoreColorFactory();
        _slotImage.color = colorFactory.Get(entity.TypeCore);

        base.OnAdded(entity);

    }
}

