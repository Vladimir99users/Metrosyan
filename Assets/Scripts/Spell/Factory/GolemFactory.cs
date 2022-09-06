using System.Collections.Generic;
using UnityEngine;

public class GolemFactory : MonoBehaviour 
{
    [SerializeField] private Golem _golem;
    public Spell Get(Core mainCore)
    {
        AttackFactoryBase _attaclFactory;
        _attaclFactory = new RangeAttackFactory();

        IAttack attack = _attaclFactory.Get(mainCore.Stats);

        Golem golem = Instantiate(_golem);
        golem.Init(attack, mainCore);

        return golem;
    }
}

public interface IInputLisener
{
    void EnableInput();
    void DisableInput();
}