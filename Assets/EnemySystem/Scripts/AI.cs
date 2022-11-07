using UnityEngine;

[RequireComponent(typeof(LookTargetAI),typeof(MoveAI),typeof(CreatureHealthAI))]
public class AI : Enemy
{

    [Header("Вспомогательные объекты")]
    [SerializeField] private GameObject _dotPatrol;

    [Header("Тип Врага")]
    [SerializeField] private EnemyType _typeEnemy = EnemyType.None;

    [Header("Настройки врага")]
    [SerializeField] protected LayerMask _whatCanBeAttackedMask;
    [SerializeField][Range(0,50)] private int _damageAI = 25;
    [SerializeField][Range(0,10)] private float _attackSpeed = 1f;
    [SerializeField][Range(0,50)] internal float PatrolRadius = 25f;
    [SerializeField][Range(3,10)] internal float RangeAttackedAI = 5f;

    #region PrivateVariable
        private StateCreature _state = StateCreature.Idle;
        private Transform _pointAroundWhichPatrol;
        private float _attackCooldown = 0f;
        private float _rangeIdleState = 3f;
        private bool _isFindPlayer = false;
        private bool _isStoped = false;
        private bool _isAttack = false;
        private CreatureHealth _targetForPursuit = null;
        private CreatureHealth _targetForAttacked = null;
    #endregion

    #region GetComponentVariable
        private Animator _animator => GetComponent<Animator>();
        private MoveAI _moveAI => GetComponent<MoveAI>();
        private LookTargetAI _lookAI => GetComponent<LookTargetAI>();

    #endregion

    private void Start()
    {
        Init(gameObject.transform);
    }
    public override void Init(Transform position)
    {
        var pointer = Instantiate(_dotPatrol,position);
        _pointAroundWhichPatrol = pointer.transform;
        pointer.transform.parent = null;
        
    }

    private void Update()
    {
        _isFindPlayer = TryCheckPlayer(_whatCanBeAttackedMask);
  
        _isAttack = !(_targetForPursuit != null && TryAttacked(_targetForPursuit.transform));

        _attackCooldown -= Time.deltaTime;

        if(TryCheckIdle()) 
        {
            _isStoped = true;
            _state = StateCreature.Idle;
        } else 
        {
            _isStoped = false;
        }


        if(_isFindPlayer == true && _isAttack == true)  
        {
            _state = StateCreature.Walking;
        } 

        ClampRangeAttacked();

        if(_state == StateCreature.Attacked)
        {
            _moveAI.TryStopedAgent(true);
        } else if(_state == StateCreature.Walking)
        {
            _moveAI.TryStopedAgent(false);
        }

        AnimatorState(_state);
    }

    private bool TryCheckPlayer(LayerMask foundMask)
    {
        return Physics.CheckSphere(gameObject.transform.position,PatrolRadius,foundMask);
    }
    private bool TryAttacked(Transform creature)
    {
        return (Vector3.Distance(gameObject.transform.position, creature.position) < RangeAttackedAI);
    }
    private bool TryCheckIdle()
    {
        return Vector3.Distance( transform.position, _pointAroundWhichPatrol.position) < _rangeIdleState;
    }
    private void ClampRangeAttacked()
    {
        RangeAttackedAI = Mathf.Clamp(RangeAttackedAI,_rangeIdleState,PatrolRadius);
    }

    private void FixedUpdate()
    {
     
        if(_isFindPlayer == true)
        {
           Collider[] colPursuit = Physics.OverlapSphere(gameObject.transform.position,PatrolRadius,_whatCanBeAttackedMask);
           Collider[] colAttacked = Physics.OverlapSphere(gameObject.transform.position,RangeAttackedAI,_whatCanBeAttackedMask);
           
           if(colPursuit.Length <= 0)   return;
 
            _targetForPursuit = colPursuit[0].GetComponent<CreatureHealth>();

            if(colAttacked.Length > 0)  
                _targetForAttacked = colAttacked[0].GetComponent<ITakeDamage>() as CreatureHealth;

            _lookAI.LookRotationTarget(_targetForPursuit.transform);
            if(_isAttack) 
            {
                _targetForAttacked = null;
                _moveAI.MoveAgent(_targetForPursuit.transform);
            } 
            else 
            {
                _state = StateCreature.Attacked;
            }

        } else if(_isFindPlayer == false && _isStoped == false) 
        {      
            _moveAI.TryStopedAgent(false);
            _targetForPursuit = null;
            _lookAI.LookRotationTarget(_pointAroundWhichPatrol);
            _state = StateCreature.Walking;
            _moveAI.MoveAgent(_pointAroundWhichPatrol);
        }

    }
    protected override void AttackTarget()
    {
        if(_attackCooldown <= 0)
        {
            if(_targetForAttacked is ITakeDamage)
            {
                _targetForAttacked.TakeDamage( _damageAI);
                Debug.Log("Я нанёс = " + _damageAI);
                _attackCooldown = 1f / _attackSpeed;
            }
        }
        
    }

    private void OnDestroy()
    {
        if(_typeEnemy == EnemyType.None) return;
        
        EventManadger.SendMessageKillEnemy(_typeEnemy);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(gameObject.transform.position,_rangeIdleState);
    }
    public void AnimatorState(StateCreature state)
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
            case StateCreature.Die:
                _animator.SetBool("IsDie", true);
                break;
            default: Debug.LogError("None trigger");
            break;
        }
    }
}
