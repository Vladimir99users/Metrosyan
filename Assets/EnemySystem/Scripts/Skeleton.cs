using UnityEngine;

public class Skeleton : Enemy
{
    private float _patrolRadius = 30f;
    [SerializeField]private Animator _animator;
    public override void Init(Transform position)
    {
        _pointAroundWhichPatrol = position;
        Debug.Log("Я скелетон");
    }



    private void FixedUpdate()
    {
       if(Physics.CheckSphere(gameObject.transform.position,_patrolRadius,_playerMask))
       {
            Collider[] col = Physics.OverlapSphere(gameObject.transform.position,_patrolRadius,_playerMask);
           
            Debug.Log(col.Length);

           if(col.Length <= 0) 
           {
                _animator.SetTrigger("Idle");
                return;
           }

            PlayerSearch(col[0].GetComponent<Player>());
       } else 
       {
            _agent.SetDestination(_pointAroundWhichPatrol.position);
       }
    }

    public override void PlayerSearch(Player player)
    {
        _animator.SetTrigger("move");
        _agent.SetDestination(player.transform.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(gameObject.transform.position,_patrolRadius);
    }
}