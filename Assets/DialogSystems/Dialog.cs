using UnityEngine;

public class Dialog : MonoBehaviour
{
    [SerializeField] private LocalizationConversation _conversationFirst;
    [SerializeField] private LocalizationConversation _conversationSecond;

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
        ViewDialog.OnStartConfigurationDialog?.Invoke(_conversationFirst.GetConversation().Nodes);
        _conversationFirst = _conversationSecond;
    }

    public void AssignmentComplete(LocalizationConversation complete)
    {
        _conversationFirst = complete;
        Debug.Log("Assignments complete");
    }
}
