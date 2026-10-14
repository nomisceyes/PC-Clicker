using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _money;
    public int Money => _money;
    public event Action<int> OnMoneyChanged;

    public void Add(int value)
    {
        _money += value;
        OnMoneyChanged?.Invoke(_money);
    }

    public bool TrySpend(int value)
    {
        if (_money < value) return false;
        _money -= value;
        OnMoneyChanged?.Invoke(_money);
        return true;
    }
}