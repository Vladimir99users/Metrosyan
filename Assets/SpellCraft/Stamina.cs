using System;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    public event Action<float> StaminaChanged;
    public float MaxStamina => _maxStamina;

    [SerializeField] private float _maxStamina;
    [SerializeField] private float _regenPerSecond;

    private float _currentStamina;

    public bool TrySpend(float value)
    {
        if(value <= _currentStamina)
        {
            _currentStamina -= value;
            StaminaChanged?.Invoke(_currentStamina);
            return true;
        }

        return false;
    }

    private void Awake()
    {
        _currentStamina = _maxStamina;
        StaminaChanged?.Invoke(_currentStamina);
    }
    private void Update()
    {
        if(_currentStamina < _maxStamina)
        {
            _currentStamina += _regenPerSecond * Time.deltaTime;
            if (_currentStamina > _maxStamina)
                _currentStamina = _maxStamina;

            StaminaChanged?.Invoke(_currentStamina);
        }
    }

}

