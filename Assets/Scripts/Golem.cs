using UnityEngine;

public class Golem : MonoBehaviour
{
    [SerializeField] private IAttack _attackHandler;

    public void Init(IAttack attack)
    {
        _attackHandler = attack;
    }

    private void Attack()
    {
        _attackHandler.Hit();
    }
  
}
