using System.Collections.Generic;
using System.Linq;

public class Recipe
{
    public RecipeCondition[] RecipeConditions { get; }
    protected Spell _spell;

    public Recipe(Spell spell, RecipeCondition[] recipeConditions)
    {
        _spell = spell;
        RecipeConditions = recipeConditions;
    }

    public bool TryCraft(out Spell spell)
    {
        spell = null;

        if (RecipeConditions.Count() == 0)
        {
            spell = _spell;
            return true;
        }

        int _unmeetedContidions = RecipeConditions.Where(c => c.IsMeeted == false).Count();
        if( _unmeetedContidions == 0)
        {
            spell = _spell;
            return true;
        }

        return false;

    }

}
