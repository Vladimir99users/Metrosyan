using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
sealed class Skeleton : Enemy
{
   
    public override void Init(Transform position)
    {
        var _pointer = Instantiate(_dotPatrol,position);
        _pointAroundWhichPatrol = _pointer.transform;
        _pointer.transform.parent = null;
    }
    protected override void Update()
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
    protected override void FixedUpdate()
    {
    
        if(_isFindPlayer == true)
        {
          
            FindAndAttackedPlayer();
        } else if(_isFindPlayer == false && _isStoped == false) 
        {      
            _agent.isStopped = false;
            LookRotationTarget(_pointAroundWhichPatrol);
            AnimatorState(StateCreature.Walking);
            MoveAgent(_pointAroundWhichPatrol);
        }

    }

   
    protected override void AnimatorState(StateCreature state)
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