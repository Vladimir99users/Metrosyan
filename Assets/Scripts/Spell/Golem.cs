using UnityEngine;

[CreateAssetMenu(fileName = "Golem", menuName = "SpellCraft/Golem")]
public class Golem : Spell
{

    [SerializeField] private IAttack _attackHandler;
    
    public void Init(IAttack attack, Core typeCore)
    {
        _attackHandler = attack;
        TypeCore = typeCore;
    }

    public override void Use()
    {
        Debug.Log($"Spawn golem");
        Attack();
    }

    private void Attack()
    {
        _attackHandler.Hit();
    }
  
}

