using UnityEngine;

[CreateAssetMenu(fileName = "New NPC", menuName = "NPC/Create NPC")]
public class CreateNewNPC : ScriptableObject
{
    [SerializeField]private string _name;
    [SerializeField]private string _description;
    [SerializeField]private NPCType _type;
    
    public string Name=> _name ;
    public string Description => _description;
    public NPCType Type => _type;
}
