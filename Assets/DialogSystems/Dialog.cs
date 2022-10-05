using UnityEngine;
using System.Collections.Generic;
public class Dialog : MonoBehaviour
{
    [SerializeField] private List<LocalizationTextFile<Conversation>> _conversationFirst;
    [SerializeField] private LocalizationTextFile<Conversation> _conversationSecond;

    [SerializeField] private RemakeQuest.GiverQuest _giver => GetComponent<RemakeQuest.GiverQuest>();
    private int indexConvarsation = 0;

    private void Start()
    {
        if (_conversationFirst is null) Debug.LogError("НЕТ ДИАЛОГА ДЕНИС БЛЯДЬ");
        indexConvarsation= 0;
        
        if(_conversationFirst[i].GetTextFile().Quest != null)
        {
            ResetAllQuest();
        }
    }

    private void ResetAllQuest()
    {
        for(int i =0 ;i < _conversationFirst.Count;i++)
        {
            _conversationFirst[i].GetTextFile().Quest.ResetQuest();
        }
    }
    public void StartDialog()
    {
        OnFirstConversationEnterAndQuestGive();       
    }

    public void OnFirstConversationEnterAndQuestGive()
    {
        if(indexConvarsation >= _conversationFirst.Count)
        {
            ViewDialog.OnStartConfigurationDialog?.Invoke(_conversationSecond.GetTextFile().Nodes);
            Debug.Log("NONE DIALOG");
            return;
        }
        
        ViewDialog.OnStartConfigurationDialog?.Invoke(_conversationFirst[indexConvarsation].GetTextFile().Nodes);        
        CheckingForQuestAndDisplaying();
    }

    public void CheckingForQuestAndDisplaying()
    {
        if(_conversationFirst[indexConvarsation].GetTextFile().Quest != null && _conversationFirst[indexConvarsation].GetTextFile().Quest.TryGive())
        {
            Debug.Log("Index  = " +  indexConvarsation);
            _giver.InitQuestToPlayer(_conversationFirst[indexConvarsation].GetTextFile().Quest);
            _conversationFirst[indexConvarsation].GetTextFile().Quest.OnCompleteQuest.AddListener(AssignmentComplete);
        }
    }

    private void AssignmentComplete()
    {
        indexConvarsation += 1;
        if(indexConvarsation >= _conversationFirst.Count)
        {
            return;
        }
        Debug.Log("Assignments complete");
    }
}
