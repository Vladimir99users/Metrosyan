using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public abstract void Init(Transform position);
    protected abstract void AttackTarget();
}
