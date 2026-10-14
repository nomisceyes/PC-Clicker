using UnityEngine;

[CreateAssetMenu(menuName = "Clicker/Effects/Auto Income")]
public class AutoIncomeEffect : UpgradeEffect
{
    public override void Apply(UpgradeContext ctx, int value)
        => ctx.AutoClicker.IncreaseIncome(value);
}