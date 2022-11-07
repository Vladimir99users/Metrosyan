using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIQuestGoal : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _descriptionTextMP;
    [SerializeField] private Image _iconGoal;

    public void Init(string description, Sprite texture)
    {
        _iconGoal.sprite = texture;
        _descriptionTextMP.text = description;
    }
}
