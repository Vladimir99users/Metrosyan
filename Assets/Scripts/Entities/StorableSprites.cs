using System;
using System.Collections.Generic;
using UnityEngine;

public class StorableSprites : ScriptableObject
{
    [SerializeField] private Sprite _default;
    [SerializeField] private Sprite _golem;


    [SerializeField] private Dictionary<Type, Sprite> _sprites;

    private void Awake()
    {
        _sprites = new Dictionary<Type, Sprite>()
        {
            [typeof(Golem)] = _golem
        };
    }
    public Sprite GetSpriteById(Type id)
    {
        if (_sprites.ContainsKey(id))
        {
            return _sprites[id];
        }
        else return _default;
    }
        
}