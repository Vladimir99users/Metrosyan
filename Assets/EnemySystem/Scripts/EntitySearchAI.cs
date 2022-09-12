using UnityEngine;

[RequireComponent(typeof(LookTargetAI),typeof(MoveAI),typeof(RangeAttackAI))]
public class EntitySearchAI : MonoBehaviour
{
    [SerializeField][Range(0,50)] private float _patrolRadius = 25f;
    [SerializeField] private Color _color = Color.black;
    public float PatrolRadius => _patrolRadius;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = _color;
        Gizmos.DrawWireSphere(gameObject.transform.position,_patrolRadius);
    }

    public bool TryCheckPlayer(LayerMask foundMask)
    {
        return Physics.CheckSphere(gameObject.transform.position,_patrolRadius,foundMask);
    }

}
