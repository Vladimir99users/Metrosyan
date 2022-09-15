using UnityEngine;
public class TriggerDialog : MonoBehaviour
{
    [SerializeField] private Conversation _conversationFirst;
    [SerializeField] private Conversation _conversationSecond;
    [SerializeField] private Transform _positionDialog;
    private int indexConvarsation = 0;

    private void Start()
    {
        if(_conversationFirst is null) Debug.LogError("НЕТ ДИАЛОГА ДЕНИС БЛЯДЬ");
    }


    private void OnTriggerExit()
    {
        if(_conversationSecond is null) return;

        _conversationFirst = _conversationSecond;
        ViewDialog.OnCloseConfigurationDialog?.Invoke();
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
