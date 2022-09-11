using UnityEngine;

public class AuraAttack : Attack
{
    private float _damage;
    private float _radius;

    public AuraAttack(float damage, float radius)
    {
        _damage = damage;
        _radius = radius;
    }

    public override void Hit()
    {
        Debug.Log($"Я аура я бъю {_damage} на радиус {_radius}");
    }
}
