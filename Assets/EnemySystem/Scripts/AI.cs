using UnityEngine;

[RequireComponent(typeof(EntitySearchAI),typeof(CreatureHealthAI))]
public class AI : Enemy
{
   
    [SerializeField] private StateCreature _state = StateCreature.Idle;
    [SerializeField] private GameObject _dotPatrol;
    [SerializeField][Range(0,50)] private int _damageAI = 25;
    [SerializeField][Range(0,10)] private int _rangeIdleState = 3;
    [SerializeField][Range(0,10)] private float _attackSpeed = 1f;
    [SerializeField] protected LayerMask _whatCanBeAttackedMask;
    [SerializeField]private Animator _animator;

    private float _attackCooldown = 0f;
    private bool _isFindPlayer = false;
    private bool _isStoped = false;
    private bool _isAttack = false;

    private CreatureHealth _creatureHealth = null;

    private MoveAI _moveAI => GetComponent<MoveAI>();
    private LookTargetAI _lookAI => GetComponent<LookTargetAI>();
    private EntitySearchAI _searchAttaked => GetComponent<EntitySearchAI>();
    private RangeAttackAI _rangeArrakedAI => GetComponent<RangeAttackAI>();

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
        _isFindPlayer = _searchAttaked.TryCheckPlayer(_whatCanBeAttackedMask);
  
        _isAttack = !(_creatureHealth != null && _rangeArrakedAI.TryAttacked(_creatureHealth.transform));

        _attackCooldown -= Time.deltaTime;

       if(Vector3.Distance( transform.position, _pointAroundWhichPatrol.position) < _rangeIdleState) 
       {
           _isStoped = true;
           _state = StateCreature.Idle;
       } else _isStoped = false;

        if(_isFindPlayer == true && _isAttack == true)    _state = StateCreature.Walking;


        
    }
   private void FixedUpdate()
    {
     
        if(_isFindPlayer == true)
        {
           Collider[] col = Physics.OverlapSphere(gameObject.transform.position,_searchAttaked.PatrolRadius,_whatCanBeAttackedMask);
           

           if(col.Length <= 0)   return;
 
            _creatureHealth = col[0].GetComponent<ITakeDamage>() as CreatureHealth;
            _lookAI.LookRotationTarget(_creatureHealth.transform);
            if(_isAttack) 
            {
                _moveAI.TryStopedAgent(false);
                _moveAI.MoveAgent(_creatureHealth.transform);
            } 
            else 
            {
                _moveAI.TryStopedAgent(true);
                _state = StateCreature.Attacked;
            }

        } else if(_isFindPlayer == false && _isStoped == false) 
        {      
            _moveAI.TryStopedAgent(false);
            _creatureHealth = null;
            _lookAI.LookRotationTarget(_pointAroundWhichPatrol);
            _state = StateCreature.Walking;
            _moveAI.MoveAgent(_pointAroundWhichPatrol);
        }

    }

    private void LateUpdate()
    {
        AnimatorState(_state);
    }
    public void AttackTarget()
    {
        if(_attackCooldown <= 0)
        {
            if(_creatureHealth is ITakeDamage)
            {
                _creatureHealth.TakeDamage( _damageAI);
                Debug.Log("Я нанёс = " + _damageAI);
                _attackCooldown = 1f / _attackSpeed;
            }
        }
        
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
