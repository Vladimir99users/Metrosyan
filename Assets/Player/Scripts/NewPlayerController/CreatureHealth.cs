using UnityEngine;

public class CreatureHealth : MonoBehaviour, ITakeDamage
{
  
    [Tooltip("все показания игрока")][SerializeField] private CreatureStates _creatureState;
    public bool IsDie =false;



    private void Start()
    {
        _creatureState._healthBar.maxValue = _creatureState.Health;
        _creatureState._healthBar.value = _creatureState._healthBar.maxValue;
    }
    public void TakeDamage(int damage)
    {
       _creatureState.Health -= damage;
       _creatureState._healthBar.value = _creatureState.Health;
        AnimatorCreature._onStateCreature?.Invoke(StateCreature.Damage);
       if(_creatureState.Health <= 0)
       {
            IsDie =true;
            AnimatorCreature._onStateCreature?.Invoke(StateCreature.Die);
       } 
    }
}
