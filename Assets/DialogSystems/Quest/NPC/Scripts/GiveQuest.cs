using UnityEngine;

[RequireComponent(typeof(NameNPC))]
public class GiveQuest : MonoBehaviour
{
    [SerializeField] protected Quest.Quest _quest;

    [SerializeField] protected NameNPC _npc => GetComponent<NameNPC>();


    public virtual void SendMessageIntheWorld()
    {
        EventManadger.OnNPCTalk?.Invoke(_npc.NPC);
        GiveQuestPlayer();
    }

    protected virtual void GiveQuestPlayer()
    {
        if (_quest != null)
        {
            _quest.InitializationQuest();
        } 
    }
}
