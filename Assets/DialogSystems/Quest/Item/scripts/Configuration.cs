using UnityEngine;

namespace Quest.ItemConfiguration
{
    [CreateAssetMenu(fileName = "New item", menuName = "Create Quest/Configuration new item")]
    public class Configuration : ScriptableObject
    {
        [SerializeField] private Vector3[] _points;
        [SerializeField] private Item _item;
        [SerializeField] private string _nameItem;

        public Vector3[] Points => _points;
        public Item Item => _item;
        public string NameItem => _nameItem;
    }

}

