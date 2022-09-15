using UnityEngine;

public class Dialog : MonoBehaviour
{
    [SerializeField] private Conversation _conversationFirst;
    [SerializeField] private Conversation _conversationSecond;

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
        ViewDialog.OnStartConfigurationDialog?.Invoke(_conversationFirst.Nodes);
    }

    public void AssignmentComplete(Conversation complete)
    {
        _conversationFirst = complete;
        Debug.Log("Assignments complete");
    }

}
