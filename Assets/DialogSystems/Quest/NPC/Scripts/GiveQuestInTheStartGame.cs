using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveQuestInTheStartGame : GiveQuest
{
    private void Start() 
    {
        GiveQuestPlayer();
    }
    protected override void GiveQuestPlayer()
    {
        if (_quest != null)
        {
            _quest.InitializationQuest();
        } else 
        {
             Debug.Log("<color=red> " + string.Format($"У NPC с именем {gameObject.name}{_npc.Name} нет квеста, это точно так нужно?" + "</color>"));
        }
    }

    public override void SendMessageIntheWorld()
    {
        EventManadger.OnNPCTalk?.Invoke(_npc);
    }
}
