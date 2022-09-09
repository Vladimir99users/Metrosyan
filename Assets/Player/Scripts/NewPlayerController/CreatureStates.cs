using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public struct CreatureStates
{
    [Header("настраиваемая часть")]
    [Tooltip("жизни существа")]public int Health;
    
    [Header("Визуальная часть")]
    public Slider _healthBar;
}