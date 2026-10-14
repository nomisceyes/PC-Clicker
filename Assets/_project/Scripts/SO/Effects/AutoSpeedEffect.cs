using UnityEngine;

[CreateAssetMenu(menuName = "Clicker/Effects/Auto Speed")]
public class AutoSpeedEffect : UpgradeEffect
{
    [Tooltip("Сколько секунд отнимает один уровень")]
    public float SecondsPerLevel = 0.05f;

    public override void Apply(UpgradeContext ctx, int value)
        => ctx.AutoClicker.DecreaseInterval(value * SecondsPerLevel);
}