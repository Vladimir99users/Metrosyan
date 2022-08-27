public class SpellSlotPresenter : SlotPresenter<Spell>
{
    protected override void OnAdded(Spell entity)
    {
        base.OnAdded(entity);

        CoreColorFactory colorFactory = new CoreColorFactory();
        _slotImage.color = colorFactory.Get(entity.TypeCore);
    }
}

