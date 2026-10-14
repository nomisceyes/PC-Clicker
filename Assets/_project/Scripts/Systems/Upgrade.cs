using UnityEngine;

public class Upgrade
{
    public UpgradeData Data { get; }
    public int Level { get; private set; }
    public int CurrentCost { get; private set; }

    public bool IsMaxLevel => Data.MaxLevel > 0 && Level >= Data.MaxLevel;

    public Upgrade(UpgradeData data)
    {
        Data = data;
        Level = 0;
        CurrentCost = data.BaseCost;
    }
    
    public bool TryLevelUp()
    {
        if (IsMaxLevel) return false;

        Level++;
        CurrentCost = Mathf.RoundToInt(CurrentCost * Data.CostMultiplier);
        return true;
    }
}