using System;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    [SerializeField] private float _comboWindow = 1.5f;
    [SerializeField] private int _maxCombo = 10;

    private int _combo;
    private float _lastClickTime = float.NegativeInfinity;

    public int Combo => _combo;
    public int Multiplier => Mathf.Min(_combo + 1, _maxCombo);

    public event Action<int> OnComboChanged;

    private void Update()
    {
        if (_combo > 0 && Time.time - _lastClickTime > _comboWindow)
        {
            _combo = 0;
            OnComboChanged?.Invoke(_combo);
        }
    }

    public int RegisterClick()
    {
        if (Time.time - _lastClickTime <= _comboWindow)
            _combo = Mathf.Min(_combo + 1, _maxCombo - 1);
        else
            _combo = 0;

        _lastClickTime = Time.time;
        OnComboChanged?.Invoke(_combo);

        return Multiplier;
    }
}