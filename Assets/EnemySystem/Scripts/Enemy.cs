using UnityEngine;
using UnityEngine.AI;
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected StateEnemy _stateEnemy = StateEnemy.Idle;
    [SerializeField] protected Transform _pointAroundWhichPatrol;
    [SerializeField] protected NavMeshAgent _agent;
    [SerializeField] protected LayerMask _playerMask;
    public abstract void Init(Transform position);
    public abstract void PlayerSearch(Player player);
}
