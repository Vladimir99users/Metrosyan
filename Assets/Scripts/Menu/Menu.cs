using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CanvasGroup))]
public abstract class Menu : MonoBehaviour
{
    public bool IsOpen => _canvasGroup.interactable;

    public UnityEvent Opened;
    public UnityEvent Closed;

    [SerializeField] private bool _closeOnAwake = true;
    private CanvasGroup _canvasGroup;

    public virtual void Open()
    {
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.alpha = 1;
    }
    public virtual void Close()
    {
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.alpha = 0;
    }

    protected virtual void OnAwake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Awake()
    {
        OnAwake();

        if (_closeOnAwake)
        {
            Close();
        }
    }

}
