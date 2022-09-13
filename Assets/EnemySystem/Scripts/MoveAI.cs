using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MoveAI : MonoBehaviour
{
    private NavMeshAgent _agent => GetComponent<NavMeshAgent>();
    public void MoveAgent(Transform dot)
    {
        _agent.SetDestination(dot.transform.position);
    }

    public void TryStopedAgent(bool flag)
    {
        _agent.isStopped = flag;
    }
}
