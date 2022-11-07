using UnityEngine;

[RequireComponent(typeof(NameNPC))]
public class GiveQuestInteractable : GiveQuest
{

    public override void SendMessageIntheWorld()
    {
        EventManadger.SendWithNPC(_npc.NPC);
    }
    public override void GiveQuestPlayer()
    {
        EventManadger.OnDialogEnd.AddListener(StartInitializeQuest);
    }
    private void StartInitializeQuest()
    {
        if (_quest != null)
        {
            _quest.InitializationQuest();
        } 
    }
}
