using UnityEngine;


[CreateAssetMenu(fileName = "MagicBallCast", menuName = "Spell/MagicBallCast")]
public class MagicBallCast : Spell
{
    private MagicBall _ballPrevab;
    private int _damage;
    public void Init(MagicBall magicBall, int damage, Core core)
    {
        _ballPrevab = magicBall;
        _damage = damage;
        _core = core;
    }

    public override void Use(Vector3 castPosition = default, Vector3 direction = default, GameObject target = null)
    {
        var ball = GameObject.Instantiate(_ballPrevab, castPosition + new Vector3(0, 1f), Quaternion.Euler(direction));
        ball.Init(_damage);
        ball.Launch(direction);
    }
}
