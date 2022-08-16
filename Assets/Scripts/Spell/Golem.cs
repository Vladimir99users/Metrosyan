using UnityEngine;

public class Golem : Spell
{
    [SerializeField] private IAttack _attackHandler;

    public Golem(IAttack attack)
    {
        _attackHandler = attack;
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
