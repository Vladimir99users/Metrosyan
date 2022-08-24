public class RecipeCondition 
{
    public IngredientType Type { get; }
    public int Amout { get; }
    public bool IsMeeted { get; private set; }

    public RecipeCondition(IngredientType type, int amout)
    {
        Type = type;
        Amout = amout;
    }

    public bool TryMeet(int amount)
    {
        IsMeeted = Amout >= amount;
        return IsMeeted;
    }
   
}
