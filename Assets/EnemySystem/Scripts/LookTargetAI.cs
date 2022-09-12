using UnityEngine;
using UnityEngine.AI;

public class LookTargetAI : MonoBehaviour
{
    private NavMeshAgent _agent => GetComponent<NavMeshAgent>();
    public void LookRotationTarget(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation,lookRotation, Time.deltaTime * _agent.angularSpeed);
    }
}