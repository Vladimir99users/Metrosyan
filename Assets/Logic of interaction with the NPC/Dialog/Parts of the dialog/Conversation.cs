using System.Collections.Generic;
using UnityEngine;


namespace DialogSystem.Item
{
    [CreateAssetMenu(fileName = "Conversation", menuName = "Conversation/Dialog/Conversation")]
    public class Conversation : ScriptableObject
    {
        [SerializeField] private List<Node> _nodes;
        [SerializeField] private Quest.Quest _quest;
        public List<Node> Nodes => _nodes;
        public Quest.Quest Quest => _quest;  
    
    }
}
