using UnityEngine;
using UnityEngine.AI;


public class MeleeCombatEnemy : Enemy
{
    public override void Init(Transform position)
    {
        var _pointer = Instantiate(_dotPatrol,position);
        _pointAroundWhichPatrol = _pointer.transform;
        _pointer.transform.parent = null;
    }
    protected bool TryCheckPlayer()
    {
       return Physics.CheckSphere(gameObject.transform.position,_patrolRadius,_attackedMask,QueryTriggerInteraction.Ignore);
    }

    protected bool TryStopPlayer()
    {
        return Vector3.Distance( transform.position, _pointAroundWhichPatrol.position) < _rangeIdleState;
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