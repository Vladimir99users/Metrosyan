using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CreatureHealth : MonoBehaviour, ITakeDamage
{
    public UnityEvent Dead;
    public UnityEvent Alive;
    [Tooltip("все показания игрока")][SerializeField] protected CreatureStates _creatureState;
    [SerializeField] private RespawnPoint _respawn;
    
    private bool _isDeath;

    private void Start()
    {
        OnStart();
    }

    public virtual void OnStart()
    {
        _creatureState._healthBar.maxValue = _creatureState.Health;
        _creatureState._healthBar.value = _creatureState._healthBar.maxValue;
    }

    public void RestoreHP()
    {
        _creatureState.Health = 100;
        _creatureState._healthBar.value = _creatureState.Health;
    }
    public virtual void TakeDamage(int damage)
    {
       _creatureState.Health -= damage;
       _creatureState._healthBar.value = _creatureState.Health;
        AnimatorCreature._onStateCreature?.Invoke(StateCreature.Damage);
       if(_creatureState.Health <= 0)
       {
            if(_respawn != null && _isDeath == false)
            {
                _isDeath = true;
                Dead?.Invoke();
                StartCoroutine(Respawn());
            }
       } 
    }

    private IEnumerator Respawn()
    {
        //AnimatorCreature._onStateCreature?.Invoke(StateCreature.Die);
        GetComponent<Player>().DisableAllAction();
        yield return new WaitForSeconds(3f);
        _respawn.Respawn();
        //AnimatorCreature._onStateCreature?.Invoke(StateCreature.Alive);
        _isDeath = false;
        Alive?.Invoke();  
    } 
}
