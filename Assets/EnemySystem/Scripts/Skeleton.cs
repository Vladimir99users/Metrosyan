using UnityEngine;

public class Skeleton : Enemy
{
    [SerializeField][Range(0,50)] private float _patrolRadius = 25f;
    [SerializeField][Range(0,10)] private float _rangeAttacked = 3f;
    [SerializeField]private Animator _animator;
    [SerializeField] private GameObject _dotPatrol;

    private bool _isFindPlayer = false;
    private bool _isStoped = false;
    public override void Init(Transform position)
    {
        var _pointer = Instantiate(_dotPatrol,position);
        _pointAroundWhichPatrol = _pointer.transform;
        _pointer.transform.parent = null;
    }


    private void Update()
    {
       if(Physics.CheckSphere(gameObject.transform.position,_patrolRadius,_playerMask))
       {
            _isFindPlayer = true;
       }         
       else _isFindPlayer = false;

       if(Vector3.Distance( transform.position, _pointAroundWhichPatrol.position) < 0.5f) 
       {
           _isStoped = true;
           _stateEnemy = StateEnemy.Idle;
           AnimatorState(_stateEnemy);
       } else _isStoped = false;
    }
    private void FixedUpdate()
    {
        if(_isFindPlayer == true)
        {
           Collider[] col = Physics.OverlapSphere(gameObject.transform.position,_patrolRadius,_playerMask);
           if(col.Length <= 0)   return;
            _stateEnemy = StateEnemy.Walking;
            AnimatorState(_stateEnemy);
            Player _player = col[0].GetComponent<Player>();
            if(Vector3.Distance(gameObject.transform.position, _player.transform.position) > _rangeAttacked)  MoveAgent(_player.transform);
            else 
            {
                _stateEnemy = StateEnemy.Attacked;
                AnimatorState(_stateEnemy);
            }

        } else if(_isFindPlayer == false && _isStoped == false) 
        {
            _stateEnemy = StateEnemy.Walking;
            AnimatorState(_stateEnemy);
            MoveAgent(_pointAroundWhichPatrol);
        }
    }

    public override void MoveAgent(Transform dot)
    {
        _agent.SetDestination(dot.transform.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(gameObject.transform.position,_patrolRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(gameObject.transform.position,_rangeAttacked);
    }
    private void AnimatorState(StateEnemy state)
    {
        switch (state)
        {
            case StateEnemy.Walking:
                _animator.SetTrigger("move");
                _animator.ResetTrigger("Idle");
                break;
            case StateEnemy.Idle:
                _animator.SetTrigger("Idle");
                _animator.ResetTrigger("move");
                break;
            case StateEnemy.Attacked:
                _animator.ResetTrigger("move");
                _animator.ResetTrigger("Idle");
                _animator.SetTrigger("attacked");
                break;
            default: Debug.LogError("None trigger");
            break;
        }
    }
}