using UnityEngine;
public class Skeleton : MeleeCombatEnemy
{
     private void Update()
     {
          _attackCooldown -= Time.deltaTime;
           _isAttack = !(Player != null && Vector3.Distance(gameObject.transform.position, Player.transform.position) < _rangeAttacked);   


          if(TryStopPlayer())
          {
              AnimatorState(StateCreature.Idle);
          }
          if(TryCheckPlayer() == true && _isAttack == true)   AnimatorState(StateCreature.Walking);
     }

     private void FixedUpdate()
     {
    
        if(TryCheckPlayer() == true)
        {
            FindAndAttackedPlayer();
        } else if(TryCheckPlayer() == false && TryStopPlayer() == false) 
        {      
            _agent.isStopped = false;
            LookRotationTarget(_pointAroundWhichPatrol);
            AnimatorState(StateCreature.Walking);
            MoveAgent(_pointAroundWhichPatrol);
        }

     }
   
}
