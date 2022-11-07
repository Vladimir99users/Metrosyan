using UnityEngine;

public class NameNPC : MonoBehaviour
{
    [SerializeField] private CreateNewNPC _npc;

    public CreateNewNPC NPC => _npc;
}
