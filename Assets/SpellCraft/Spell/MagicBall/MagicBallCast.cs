using UnityEngine;


[CreateAssetMenu(fileName = "MagicBallCast", menuName = "Spell/MagicBallCast")]
public class MagicBallCast : Spell
{
    private MagicBall _ballPrevab;

    public void Init(MagicBall magicBall)
    {
        _ballPrevab = magicBall;
    }
    public override void Use(Vector3 castPosition = default, Vector3 direction = default, GameObject target = null)
    {
        Debug.Log($"Кастую мяч {castPosition}");
        var ball = GameObject.Instantiate(_ballPrevab, castPosition + new Vector3(0, 1f), Quaternion.Euler(direction));
        ball.Launch(direction);
    }
}
