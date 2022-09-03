using UnityEngine;

public class TriggerDialog : MonoBehaviour
{
    [SerializeField] private Conversation _conversation;
    [SerializeField] private Conversation _defualtConversation;
    [SerializeField] private Transform _positionDialog;
    private int indexConvarsation = 0;
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {    
            //if(_conversation.Length <= indexConvarsation) indexConvarsation = _conversation.Length-1;  
            ViewDialog.OnStartConfigurationDialog?.Invoke(_conversation.Nodes);
           
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_positionDialog.position,8f);
    }
    private void OnTriggerExit()
    {
        _conversation = _defualtConversation;
        ViewDialog.OnCloseConfigurationDialog?.Invoke();
    }

    public void AssignmentComplete(Conversation complete)
    {
        _conversation = complete;
        Debug.Log("Assignments complete");
    }
}
