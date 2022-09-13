using UnityEngine;
using UnityEngine.Events;

public class PlayerTriggerZone : MonoBehaviour
{
    public UnityEvent OnEnter;
    public UnityEvent OnExit;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Player>(out Player player) == false)
        {
            return;
        }

        OnEnter?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player) == false)
        {
            return;
        }

        OnExit?.Invoke();
    }

}
