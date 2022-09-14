using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InteratableZone))]
public class ShowImageInteraction : MonoBehaviour
{
    [SerializeField] private Image _image;
    private InteratableZone _zone;

    public void Awake()
    {
        _zone = GetComponent<InteratableZone>();
    }

    public void OnEnable()
    {
        _zone.ZoneEnter.AddListener(Show);
        _zone.ZoneExit.AddListener(Hide);
    }

    public void OnDisable()
    {
        _zone.ZoneEnter.RemoveListener(Show);
        _zone.ZoneExit.RemoveListener(Hide);
    }

    public void Show()
    {
        _image.enabled = true;
    }

    public void Hide()
    {
        _image.enabled = false;
    }
}
