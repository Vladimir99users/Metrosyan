using UnityEngine;

[RequireComponent(typeof(InteratableZone))]
public class MessageShowInteraction : MonoBehaviour
{
    [SerializeField] private UIMessage _uiMessage;
    [SerializeField] private string _text;

    private InteratableZone _zone;

    public void Awake()
    {
        _zone = GetComponent<InteratableZone>();
    }

    public void OnEnable()
    {
        _zone.ZoneEnter.AddListener(ShowMessage);
        _zone.ZoneExit.AddListener(HideMessage);
    }

    public void OnDisable()
    {
        _zone.ZoneEnter.RemoveListener(ShowMessage);
        _zone.ZoneExit.RemoveListener(HideMessage);
    }
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
