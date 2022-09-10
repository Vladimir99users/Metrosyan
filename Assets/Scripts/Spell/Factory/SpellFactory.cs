using UnityEngine;

public abstract class SpellFactory : MonoBehaviour
{
    public abstract Spell Get(Core core);
}
