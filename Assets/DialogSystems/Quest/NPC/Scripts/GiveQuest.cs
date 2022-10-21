using UnityEngine;

public class GiveQuest : MonoBehaviour
{
    [SerializeField]
    private Quest.Quest _quest;

    [SerializeField]
    private CreateNewNPC _npc;

    private void Start()
    {
        if (_quest != null)
        {
            _quest.InitializationQuest();
        }
    }

    public void SendMessageIntheWorld()
    {
        EventManadger.OnNPCTalk?.Invoke(_npc);
    }
}
