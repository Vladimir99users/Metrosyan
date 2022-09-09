using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    private List<IInputLisener> _playerInputLiseners;

    private void Awake()
    {
        _playerInputLiseners = GetComponents<IInputLisener>().ToList();
    }
    public void EnableAllAction()
    {
        foreach(var lisener in _playerInputLiseners)
        {
            lisener.EnableInput();
        }
    }

    public void DisableAllAction()
    {
        foreach(var lisener in _playerInputLiseners)
        {
            lisener.DisableInput();
        }
    }

    public void PlayerIsDie()
    {
        gameObject.layer = 6;
       // gameObject.SetActive(false);
    }
}
