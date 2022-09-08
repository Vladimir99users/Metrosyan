using UnityEngine;
using UnityEngine.UI;
public class CreatureHealth : MonoBehaviour, ITakeDamage
{
    [Header("настраиваемая часть")]
    [Tooltip("все показания игрока")][SerializeField] private CreatureStates _creatureState;
    public bool IsDie =false;

    [Header("Визуальная часть")]
    [SerializeField] private Slider _healthBar;

    private void Start()
    {
        _healthBar.maxValue = _creatureState.Health;
        _healthBar.value = _healthBar.maxValue;
    }
    public void TakeDamage(int damage)
    {
       _creatureState.Health -= damage;
       _healthBar.value = _creatureState.Health;

       if(_creatureState.Health <= 0)
       {
            IsDie = true;
            Debug.Log("Dead");
       } 
    }
}
