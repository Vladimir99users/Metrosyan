using UnityEngine;

public class Projectale
{
    public float Damage;
    public ElementType Type;
    public GameObject Appearance;

    public Projectale(float damage, ElementType type, GameObject appearance)
    {
        Damage = damage;
        Type = type;
        Appearance = appearance;
    }
}

public enum ElementType
{
    Fire,
    Ice,
    Bullet
}