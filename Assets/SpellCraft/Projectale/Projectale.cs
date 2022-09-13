using UnityEngine;

public class Projectale
{
    public float Damage;
    public CoreType Type;
    public string Appearance;

    public Projectale(float damage, CoreType type, string appearance)
    {
        Damage = damage;
        Type = type;
        Appearance = appearance;
    }
}
