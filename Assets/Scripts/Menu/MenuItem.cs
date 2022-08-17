using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class MenuItem<TContent> : MonoBehaviour
{
    public TContent Content => content;

    [SerializeField] protected Image image;
    [SerializeField] protected TContent content;
}

