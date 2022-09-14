using UnityEngine;

public class MessageShowInteraction : MonoBehaviour
{
    [SerializeField] private UIMessage _uiMessage;
    [SerializeField] private string _text;
    public void ShowMessage()
    {
        _uiMessage.SetText(_text);
        _uiMessage.Show();
    }

    public void HideMessage()
    {
        _uiMessage.Hide();
    }
}
