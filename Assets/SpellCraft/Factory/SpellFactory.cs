using UnityEngine;

public abstract class SpellFactory : MonoBehaviour
{
    public abstract Spell Get(Core core);
}

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
            ElementType.Fire => _fireBallPrefab,
            ElementType.Ice => _iceBallPrefab,
            _ => _fireBallPrefab,
        };
    
}