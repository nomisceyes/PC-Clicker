using UnityEngine;

[CreateAssetMenu(menuName = "Clicker/Upgrade")]
public class UpgradeData : ScriptableObject
{
    public string Title = "Upgrade";
    [TextArea] public string Description;
    
    public int BaseCost = 10;
    public float CostMultiplier = 1.5f;
    
    public UpgradeEffect Effect;
    public int ValuePerLevel = 1;
    
    public int MaxLevel = 0;
}