using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BugSystem : MonoBehaviour
{
    [SerializeField] private int _baseBugChancePercent = 3;
    [SerializeField] private int _maxBugs = 50;
    [SerializeField] private int _bugs;

    public int Count => _bugs;
    public float IncomeMultiplier => 1f / (1f + _bugs * 0.04f);

    public event Action<int> OnBugsChanged;
    
    public void TrySpawnOnClick()
    {
        if (Random.Range(0, 100) < _baseBugChancePercent)
            Spawn();
    }

    public void Spawn()
    {
        if (_bugs >= _maxBugs) return;
        _bugs++;
        OnBugsChanged?.Invoke(_bugs);
    }

    public bool FixOne()
    {
        if (_bugs == 0) return false;
        _bugs--;
        OnBugsChanged?.Invoke(_bugs);
        return true;
    }
}