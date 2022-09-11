using UnityEngine;

public class GolemCaster : MonoBehaviour
{
    public Golem CastAndDisable(Golem golem, Vector3 castPosition, Vector3 direction)
    {
        Golem castedGolem = Instantiate(golem, castPosition, Quaternion.Euler(direction));
        castedGolem.gameObject.SetActive(false);
        return castedGolem;
    }
}
