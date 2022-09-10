using UnityEngine;

[CreateAssetMenu(fileName = "Golem", menuName = "SpellCraft/Golem")]
public class Golem : Spell
{

    [SerializeField] private IAttack _attackHandler;
    public override GameObject SpellGameObject { get; protected set; }

    public void Init(IAttack attack, Core typeCore)
    {
        _attackHandler = attack;
        TypeCore = typeCore;
    }

    public override void Use(Vector3 castPosition, Vector3 direction, GameObject target)
    {
        SpellGameObject = Instantiate(_spellPrefab, castPosition, Quaternion.identity);
        SpellGameObject.GetComponent<MeshRenderer>().material.color = TypeCore.Color;
        Used?.Invoke(this);
    }

    private void Attack()
    {
        _attackHandler.Hit();
    }
  
}

