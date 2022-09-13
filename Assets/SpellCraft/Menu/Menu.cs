using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CanvasGroup))]
public abstract class Menu : MonoBehaviour
{
    [SerializeField] private bool _closeOnAwake = true;


    public UnityEvent Opened;
    public UnityEvent Closed;

    public bool IsOpen => _canvasGroup.interactable;

    private CanvasGroup _canvasGroup;

    [ContextMenu("Open")]
    public virtual void Open()
    {
#if UNITY_EDITOR
        OnAwake();
#endif
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.alpha = 1;

        Opened?.Invoke();
    }

    [ContextMenu("Close")]
    public virtual void Close()
    {
#if UNITY_EDITOR
        OnAwake();
#endif
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.alpha = 0;

        Closed?.Invoke();
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
