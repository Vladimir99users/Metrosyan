using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpellSign : MonoBehaviour
{
    public Vector3 Position => transform.position;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public void Move(Vector3 position)
    {
        transform.position = position;
    }

    public void ChangeColor(Color color)
    {
        _spriteRenderer.color = color;
    }

    [ContextMenu("Show")]
    public void Show()
    {
        _spriteRenderer.enabled = true;
    }
    [ContextMenu("Hide")]
    public void Hide()
    {
        _spriteRenderer.enabled = false;
    }


}
