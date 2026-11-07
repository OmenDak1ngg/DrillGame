using UnityEngine;

public class DelayUpgrader : DrillUpgrader
{
    [SerializeField] private float _deceraseDelayAmount;

    protected override void OnReceived()
    {
        base.OnReceived();

        if (CanUpgrade == false)
            return;

        DurabilityDecreaser.DecreaseDelay(_deceraseDelayAmount);
    }
}