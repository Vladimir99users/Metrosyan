using UnityEngine;

public class EntitySearchAI : MonoBehaviour
{
    private AI _aI =>GetComponent<AI>();
    [SerializeField] private Color _color = Color.black;
    public float PatrolRadius => _aI.PatrolRadius;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = _color;
        Gizmos.DrawWireSphere(gameObject.transform.position,PatrolRadius);
    }



}
