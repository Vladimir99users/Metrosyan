using UnityEngine;

public class Caster<T> : MonoBehaviour where T : MonoBehaviour
{
    public T CastAndDisable(T prefab, Vector3 castPosition, Vector3 direction)
    {
        T newObject = Instantiate(prefab, castPosition, Quaternion.Euler(direction));
        newObject.gameObject.SetActive(false);
        return newObject;
    }
}
