using UnityEngine;

public class NewQestAdding : MonoBehaviour
{
    public QuestDescription _quest;

    public void NewQuvest()
    {
        if(_quest is null) return;

        Quest.OnAddQuest(_quest);
    }
}
