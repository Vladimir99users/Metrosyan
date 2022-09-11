using UnityEngine;

public class Item : ScriptableObject
{
    [SerializeField] protected Sprite _sprite;
    
    public Sprite Sprite => _sprite;
}

