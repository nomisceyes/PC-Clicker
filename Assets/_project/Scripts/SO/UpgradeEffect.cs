using UnityEngine;

public abstract class UpgradeEffect : ScriptableObject
{
    public abstract void Apply(UpgradeContext context, int valuePerLevel);
}