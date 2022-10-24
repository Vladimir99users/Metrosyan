using UnityEngine;

public class GiveQuest : MonoBehaviour
{
    [SerializeField] protected Quest.Quest _quest;

    [SerializeField] protected CreateNewNPC _npc;


    public virtual void SendMessageIntheWorld()
    {
        EventManadger.OnNPCTalk?.Invoke(_npc);
        GiveQuestPlayer();
    }

    protected virtual void GiveQuestPlayer()
    {
        if (_quest != null)
        {
            Debug.Log("NO");
            _quest.InitializationQuest();
        } 
    }
}
