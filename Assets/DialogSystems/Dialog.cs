using UnityEngine;
using System.Collections.Generic;
public class Dialog : MonoBehaviour
{
    [SerializeField] private List<LocalizationTextFile<Conversation>> _conversationFirst;
    [SerializeField] private LocalizationTextFile<Conversation> _conversationSecond;

    private int indexConvarsation = 0;

    private void Start()
    {
        if (_conversationFirst is null) Debug.LogError("НЕТ ДИАЛОГА ДЕНИС БЛЯДЬ");
        indexConvarsation= 0;
    }

    public void StartDialog()
    {
        OnFirstConversationEnterAndQuestGive();       
    }

    public void OnFirstConversationEnterAndQuestGive()
    {
        if(indexConvarsation >= _conversationFirst.Count)
        {
            ViewDialog.OnStartConfigurationDialog?.Invoke(_conversationSecond.GetText().Nodes);
            Debug.Log("NONE DIALOG");
            return;
        }
        
        ViewDialog.OnStartConfigurationDialog?.Invoke(_conversationFirst[indexConvarsation].GetText().Nodes);        

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
