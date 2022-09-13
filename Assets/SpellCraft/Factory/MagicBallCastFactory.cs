using UnityEngine;

public class MagicBallCastFactory : SpellFactory
{
    [SerializeField] private MagicBallCast _magicBallCastPrefab;
    [SerializeField] private MagicBall _fireBallPrefab;
    [SerializeField] private MagicBall _iceBallPrefab;

    public override Spell Get(Core core)
    {
        MagicBallCast spell = Instantiate(_magicBallCastPrefab);
        MagicBall magicBall = GetMagicBall(core);

        spell.Init(magicBall);

        return spell;
    }

    private MagicBall GetMagicBall(Core core) =>
        core.Stats.Type switch
        {
            CoreType.Fire => _fireBallPrefab,
            CoreType.Ice => _iceBallPrefab,
            _ => _fireBallPrefab,
        };
    
}