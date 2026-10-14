using UnityEngine;

[CreateAssetMenu(menuName = "Clicker/Upgrade")]
public class UpgradeData : ScriptableObject
{
    [Header("UI")]
    public string Title = "Upgrade";
    [TextArea] public string Description;
    public Sprite Icon;

    [Header("Экономика")]
    public int BaseCost = 10;
    public float CostMultiplier = 1.5f;

    [Header("Эффект")]
    public UpgradeEffect Effect;
    public int ValuePerLevel = 1;

    [Header("Ограничения")]
    public int MaxLevel = 0; // 0 = без лимита
}