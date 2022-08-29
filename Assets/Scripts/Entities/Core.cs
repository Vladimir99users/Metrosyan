
using UnityEngine;

[CreateAssetMenu(fileName = "Core", menuName = "SpellCraft/Core")]
public class Core : CraftEntity
{
    [SerializeField] protected Color _color;
    public Color Color => _color;
}
