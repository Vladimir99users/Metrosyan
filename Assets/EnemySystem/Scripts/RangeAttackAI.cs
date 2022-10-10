using UnityEngine;

public class RangeAttackAI : MonoBehaviour
{
    private AI _aI =>GetComponent<AI>();
    public float RangeAttacked => _aI.RangeAttackedAI;
    [SerializeField] private Color _color = Color.black;
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = _color;
        Gizmos.DrawWireSphere(gameObject.transform.position,RangeAttacked);
    }
}