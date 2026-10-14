using System;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    [SerializeField] private UpgradeData[] _upgradeDatas;
    [SerializeField] private UpgradeContextProvider _contextProvider;
    [SerializeField] private Wallet _wallet;

    private readonly Dictionary<UpgradeData, Upgrade> _upgrades = new();

    public event Action<Upgrade> OnUpgraded;

    private void Awake()
    {
        foreach (var data in _upgradeDatas)
            _upgrades[data] = new Upgrade(data);
    }

    public Upgrade GetUpgrade(UpgradeData data)
    {
        _upgrades.TryGetValue(data, out var upgrade);
        return upgrade;
    }

    public bool TryPurchase(UpgradeData data)
    {
        if (!_upgrades.TryGetValue(data, out var upgrade))
            return false;

        if (upgrade.IsMaxLevel) return false;

        if (!_wallet.TrySpend(upgrade.CurrentCost))
            return false;

        upgrade.TryLevelUp();
        data.Effect.Apply(_contextProvider.Context, data.ValuePerLevel);
        OnUpgraded?.Invoke(upgrade);
        return true;
    }
}