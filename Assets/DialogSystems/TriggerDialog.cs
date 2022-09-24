using UnityEngine;
using System.Collections.Generic;
public class TriggerDialog : MonoBehaviour
{

    [SerializeField] private List<LocalizationTextFile<Conversation>> _conversationFirst;
    [SerializeField] private LocalizationTextFile<Conversation> _conversationSecond;
    [SerializeField] private Transform _positionDialog;
    private int indexConvarsation = 0;

    private void Start()
    {
        if(_conversationFirst is null) Debug.LogError("НЕТ ДИАЛОГА ДЕНИС БЛЯДЬ");
    }


    private void OnTriggerExit()
    {
        if(_conversationSecond is null) return;
        ViewDialog.OnCloseConfigurationDialog?.Invoke();
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
