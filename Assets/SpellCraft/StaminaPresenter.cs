using UnityEngine;
using UnityEngine.UI;

public class StaminaPresenter : MonoBehaviour
{
    [SerializeField] private Stamina _stamina;
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        _slider.maxValue = _stamina.MaxStamina;
        _stamina.StaminaChanged += OnStaminaChanged;
    }

    private void OnDisable()
    {
        _stamina.StaminaChanged -= OnStaminaChanged;
    }

    private void OnStaminaChanged(float value)
    {
        _slider.value = value;
    }
}

