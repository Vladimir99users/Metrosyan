using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class Skeleton : Enemy
{
    [SerializeField][Range(0,50)] private float _patrolRadius = 25f;
    [SerializeField][Range(0,10)] private float _rangeAttacked = 3f;
    [SerializeField][Range(0,50)] private int _damageSkeletons = 25;
    [SerializeField][Range(0,10)] private int _rangeIdleState = 3;
    [SerializeField][Range(0,10)] private float _attackSpeed = 1f;
    [SerializeField]private Animator _animator;
    [SerializeField] private GameObject _dotPatrol;

    private float _attackCooldown = 0f;
    private bool _isFindPlayer = false;
    private bool _isStoped = false;
    private bool _isAttack = false;
    private Player _player = null;
    public override void Init(Transform position)
    {
        var _pointer = Instantiate(_dotPatrol,position);
        _pointAroundWhichPatrol = _pointer.transform;
        _pointer.transform.parent = null;
    }


    private void Update()
    {
        _isFindPlayer = Physics.CheckSphere(gameObject.transform.position,_patrolRadius,_playerMask);
        _isAttack = !(_player != null && Vector3.Distance(gameObject.transform.position, _player.transform.position) < _rangeAttacked);

        _attackCooldown -= Time.deltaTime;

       if(Vector3.Distance( transform.position, _pointAroundWhichPatrol.position) < _rangeIdleState) 
       {
           _isStoped = true;
           AnimatorState(StateCreature.Idle);
       } else _isStoped = false;

        if(_isFindPlayer == true && _isAttack == true)   AnimatorState(StateCreature.Walking);

    
     

    }
    private void FixedUpdate()
    {
        Debug.Log("Player = " + _isFindPlayer + " stoping = " + _isStoped);
        if(_isFindPlayer == true)
        {
           Collider[] col = Physics.OverlapSphere(gameObject.transform.position,_patrolRadius,_playerMask);
           if(col.Length <= 0)   return;
            //AnimatorState(StateCreature.Walking);
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

        } else if(_isFindPlayer == false && _isStoped == false) 
        {      
            LookRotationTarget(_pointAroundWhichPatrol);
            AnimatorState(StateCreature.Walking);
            MoveAgent(_pointAroundWhichPatrol);
        }

    }

    public void LookRotationTarget(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation,lookRotation, Time.deltaTime * _agent.angularSpeed);
    }
    public override void MoveAgent(Transform dot)
    {
        _agent.SetDestination(dot.transform.position);
    }

    public void AttackTarget()
    {
        if(_attackCooldown <= 0)
        {
            _player.GetComponent<ITakeDamage>().TakeDamage( _damageSkeletons);
            Debug.Log("Я нанёс = " + _damageSkeletons);
            _attackCooldown = 1f / _attackSpeed;

        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(gameObject.transform.position,_patrolRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(gameObject.transform.position,_rangeAttacked);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(gameObject.transform.position,_rangeIdleState);
    }
    private void AnimatorState(StateCreature state)
    {
        switch (state)
        {
            case StateCreature.Walking:
                _animator.SetTrigger("move");
                _animator.ResetTrigger("Idle");
                _animator.ResetTrigger("attacked");
                break;
            case StateCreature.Idle:
                _animator.SetTrigger("Idle");
                _animator.ResetTrigger("move");
                _animator.ResetTrigger("attacked");
                break;
            case StateCreature.Attacked:
                _animator.ResetTrigger("move");
                _animator.ResetTrigger("Idle");
                _animator.SetTrigger("attacked");
                break;
            default: Debug.LogError("None trigger");
            break;
        }
    }
}