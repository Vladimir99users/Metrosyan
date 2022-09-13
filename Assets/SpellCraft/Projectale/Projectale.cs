using UnityEngine;

public class Projectale
{
    public float Damage;
    public ElementType Type;
    public string Appearance;

    public Projectale(float damage, ElementType type, string appearance)
    {
        Damage = damage;
        Type = type;
        Appearance = appearance;
    }
}
