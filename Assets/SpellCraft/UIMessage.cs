using TMPro;
using UnityEngine;

public class UIMessage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void SetText(string text)
    {
        _text.text = text;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    
}