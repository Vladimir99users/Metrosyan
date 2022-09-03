using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Conversation", menuName = "Conversation/talk")]
public class Conversation : ScriptableObject
{
    [SerializeField]private List<Node> _nodes;
    public List<Node> Nodes => _nodes;
    
}
