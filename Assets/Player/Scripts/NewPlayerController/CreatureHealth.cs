using UnityEngine;

public class CreatureHealth : MonoBehaviour, ITakeDamage
{
  
    [Tooltip("все показания игрока")][SerializeField] protected CreatureStates _creatureState;

    private void Start()
    {
        OnStart();
    }

    public virtual void OnStart()
    {
        _creatureState._healthBar.maxValue = _creatureState.Health;
        _creatureState._healthBar.value = _creatureState._healthBar.maxValue;
    }
    public virtual void TakeDamage(int damage)
    {
       _creatureState.Health -= damage;
       _creatureState._healthBar.value = _creatureState.Health;
        AnimatorCreature._onStateCreature?.Invoke(StateCreature.Damage);
       if(_creatureState.Health <= 0)
       {
            AnimatorCreature._onStateCreature?.Invoke(StateCreature.Die);
       } 
    }
}
