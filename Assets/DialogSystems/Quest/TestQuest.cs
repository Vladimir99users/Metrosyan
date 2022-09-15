using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;


public class TestQuest : MonoBehaviour
{
    private Quest _quest => GetComponent<Quest>();

    [SerializeField] private QuestDescription _questDescription;

    public void AddQuestButton(string text)
    {
        _questDescription = new QuestDescription();
        _questDescription.TextQuestDescription = text;
        Quest.OnAddQuest(_questDescription);
    }

    public void RemoveQuestButton(string text)
    {
        _questDescription = new QuestDescription();
        _questDescription.TextQuestDescription = text;
        Quest.OnRemoveQuest(_questDescription);
    }
}