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
    }

    public void StartDialog()
    {
        OnFirstConversationEnter();
    }

    public void OnFirstConversationEnter()
    {
        if(indexConvarsation >= _conversationFirst.Count)
        {
            ViewDialog.OnStartConfigurationDialog?.Invoke(_conversationSecond.GetTextFile().Nodes);
            return;
        }
        ViewDialog.OnStartConfigurationDialog?.Invoke(_conversationFirst[indexConvarsation].GetTextFile().Nodes);
        indexConvarsation++;
    }

    public void AssignmentComplete(List<LocalizationTextFile<Conversation>> complete)
    {
        _conversationFirst = complete;
        indexConvarsation = 0;
        Debug.Log("Assignments complete");
    }
}
