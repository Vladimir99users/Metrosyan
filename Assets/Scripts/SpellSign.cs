using UnityEngine;

public class SpellSign : MonoBehaviour
{
    public Vector3 Position => transform.position;

    public void Move(Vector3 position)
    {
        transform.position = position;
    }

}
