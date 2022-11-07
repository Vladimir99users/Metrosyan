using UnityEngine;

[RequireComponent(typeof(NameNPC))]
sealed class GiveQuestInTheStartGame : GiveQuest
{
    private void Start() 
    {
        GiveQuestPlayer();
    }
    
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
        } else 
        {
            Debug.Log("<color=red> " + string.Format($"У NPC с именем {gameObject.name}{_npc.NPC.Name} нет квеста, это точно так нужно?"
                     + "</color>"));
        }
    }

    
}
