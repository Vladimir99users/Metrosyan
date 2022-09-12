using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected Transform _pointAroundWhichPatrol;

    public abstract void Init(Transform position);
}
