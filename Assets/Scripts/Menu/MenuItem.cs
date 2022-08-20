using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class MenuItem<TContent> : MonoBehaviour
{
    public TContent Item => _item;

    [SerializeField] protected Image image;
    [SerializeField] protected TContent _item;
}

