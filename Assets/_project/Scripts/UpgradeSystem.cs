using System;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    [SerializeField] private UpgradeData _data;
    [SerializeField] private UpgradeContextProvider _contextProvider;

    private int _level;
    private int _currentCost;

    public UpgradeData Data => _data;
    public int Level => _level;
    public int CurrentCost => _currentCost;
    public bool IsMaxLevel => _data.MaxLevel > 0 && _level >= _data.MaxLevel;

    public event Action OnUpgraded;

    private void Awake() => _currentCost = _data.BaseCost;

    public void ApplyUpgrade()
    {
        if (IsMaxLevel) return;

        _level++;
        _data.Effect.Apply(_contextProvider.Context, _data.ValuePerLevel);

        _currentCost = Mathf.RoundToInt(_currentCost * _data.CostMultiplier);
        OnUpgraded?.Invoke();
    }
}