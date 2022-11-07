using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GiveQuest : MonoBehaviour
{
    [SerializeField] protected  Quest.Quest _quest;
    [SerializeField] protected NameNPC _npc => GetComponent<NameNPC>();
    public abstract void SendMessageIntheWorld();

    public abstract void GiveQuestPlayer();
}
