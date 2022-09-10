using UnityEngine;

public class AuraAttack : IAttack
{
    private float _damage;
    private float _radius;

    public AuraAttack(float damage, float radius)
    {
        _damage = damage;
        _radius = radius;
    }

    public void Hit()
    {
        Debug.Log($"Я аура я бъю {_damage} на радиус {_radius}");
    }
}
