using UnityEngine;

public class Attacked_skeletons : StateMachineBehaviour
{

    private Enemy _enemy;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       _enemy = animator.GetComponent<Enemy>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(_enemy.Player != null)
        {
             _enemy.Player.GetComponent<ITakeDamage>().TakeDamage(10);
        }
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
