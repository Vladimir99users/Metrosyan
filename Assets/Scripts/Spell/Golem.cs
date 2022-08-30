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

    public override void Use(Vector3 castPosition, Vector3 direction)
    {
        Debug.Log($"Spawn golem");
        //Instantiate(_spellPrefab, castPosition, Quaternion.identity);
        Attack();
    }

    private void Attack()
    {
        _attackHandler.Hit();
    }
  
}

