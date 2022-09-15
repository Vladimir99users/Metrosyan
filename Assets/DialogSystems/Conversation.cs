using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Conversation", menuName = "Conversation/talk")]
public class Conversation : ScriptableObject
{
    [SerializeField]private List<Node> _nodes;
    public List<Node> Nodes => _nodes;
    
}
