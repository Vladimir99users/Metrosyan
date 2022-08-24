using System.Collections.Generic;
using UnityEngine;

public class GolemCrafter : MonoBehaviour
{
    [SerializeField] private CoreSlot _typeSlot;
    [SerializeField] private CoreSlot _extraSlot;
    [SerializeField] private CoreMenu _menu;

    private AttackFactoryBase _attackFactory = new RangeAttackFactory();

    public void Craft()
    {
        if (_typeSlot.Item is null)
            return;

        GolemFactory golemFactory = new GolemFactory();
        Spell golem = golemFactory.Get(_typeSlot.Item);
        RecipeCondition golemCondition = new RecipeCondition(IngredientType.Money, 10);
        Recipe golemRecipe = new Recipe(golem, new[] { golemCondition });
        golemRecipe.RecipeConditions[0].TryMeet(10);

        if(golemRecipe.TryCraft(out Spell craftetSpell))
        {
            craftetSpell.Use();
        }
    }
}

public class GolemConfig
{
    public Core MainCore { get;}
    public Core ExtraCore { get; }
}
