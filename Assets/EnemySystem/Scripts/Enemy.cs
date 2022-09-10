using UnityEngine;
using UnityEngine.AI;
public abstract class Enemy : MonoBehaviour
{
    [SerializeField][Range(0,50)] protected float _patrolRadius = 25f;
    [SerializeField] private Color _patrolColor = Color.blue;
    [SerializeField][Range(0,10)] protected float _rangeAttacked = 3f;
    [SerializeField] private Color _rangeColor = Color.green;
    [SerializeField][Range(0,10)] protected int _rangeIdleState = 3;
     [SerializeField] private Color _rangeIdleColor = Color.yellow;
    [SerializeField][Range(0,50)] protected int _damageSkeletons = 25;
    [SerializeField][Range(0,10)] protected float _attackSpeed = 1f;
    [SerializeField]protected Animator _animator;
    [SerializeField] protected GameObject _dotPatrol;
    [SerializeField] protected StateCreature _stateEnemy = StateCreature.Idle;
    [SerializeField] protected Transform _pointAroundWhichPatrol;
    [SerializeField] protected NavMeshAgent _agent;
    [SerializeField] protected LayerMask _playerMask;

    protected float _attackCooldown = 0f;
    protected bool _isFindPlayer = false;
    protected bool _isStoped = false;
    protected bool _isAttack = false;
    protected Player _player = null;

    public abstract void Init(Transform position);
    
    protected virtual void MoveAgent(Transform dot)
    {
        _agent.SetDestination(dot.transform.position);
    }

    protected virtual void LookRotationTarget(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation,lookRotation, Time.deltaTime * _agent.angularSpeed);
    }

    protected abstract void Update();
    protected abstract void FixedUpdate();
    protected virtual void AttackTarget()
    {
        if(_attackCooldown <= 0)
        {
            _player.GetComponent<ITakeDamage>().TakeDamage( _damageSkeletons);
            _attackCooldown = 1f / _attackSpeed;
        }
    }

    protected virtual void FindAndAttackedPlayer()
    {
           Collider[] col = Physics.OverlapSphere(gameObject.transform.position,_patrolRadius,_playerMask);
           if(col.Length <= 0)   return;

             _player = col[0].GetComponent<Player>();
             LookRotationTarget(_player.transform);
            if(_isAttack) 
            {
                _agent.isStopped = false;
                MoveAgent(_player.transform);
            } 
            else 
            {
                _agent.isStopped = true;
                AnimatorState(StateCreature.Attacked);
            }
    }

    protected virtual void OnDrawGizmosSelected()
    {
        Gizmos.color =_patrolColor;
        Gizmos.DrawWireSphere(gameObject.transform.position,_patrolRadius);
        Gizmos.color = _rangeColor;
        Gizmos.DrawWireSphere(gameObject.transform.position,_rangeAttacked);
        Gizmos.color = _rangeIdleColor;
        Gizmos.DrawWireSphere(gameObject.transform.position,_rangeIdleState);
    }
    protected abstract void AnimatorState(StateCreature state);
}
