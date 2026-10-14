using UnityEngine;

[CreateAssetMenu(menuName = "Clicker/Effects/Click Power")]
public class ClickPowerEffect : UpgradeEffect
{
    public override void Apply(UpgradeContext ctx, int value)
        => ctx.Computer.IncreaseClickPower(value);
}