using UnityEngine;

public class RangeAttackAI : MonoBehaviour
{
    [SerializeField][Range(0,10)] private float _rangeAttacked = 3f;
    [SerializeField] private Color _color = Color.black;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = _color;
        Gizmos.DrawWireSphere(gameObject.transform.position,_rangeAttacked);
    }

    public bool TryAttacked(Transform obj)
    {
        return (Vector3.Distance(gameObject.transform.position, obj.position) < _rangeAttacked);
    }
}