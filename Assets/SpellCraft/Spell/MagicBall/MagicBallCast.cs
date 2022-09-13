using UnityEngine;

public class MagicBallCast : Spell
{
    private MagicBall _ballPrevab;

    public void Init(MagicBall magicBall)
    {
        _ballPrevab = magicBall;
    }
    public override void Use(Vector3 castPosition = default, Vector3 direction = default, GameObject target = null)
    {
        var ball = GameObject.Instantiate(_ballPrevab);
        ball.Launch(direction);
    }
}
