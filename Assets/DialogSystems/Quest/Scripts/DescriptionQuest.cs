using UnityEngine;


[CreateAssetMenu(fileName = "Description", menuName = "Conversation/Description Quest")]
public class DescriptionQuest : ScriptableObject
{
     [SerializeField] private string _description;

     public string Description => _description;
}
