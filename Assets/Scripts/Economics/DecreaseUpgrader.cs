using UnityEngine;

[RequireComponent(typeof(MoneyReceiver))]
public class DecreaseUpgrader : DrillUpgrader
{
    [SerializeField] private int _increaseAmount = 1;

    protected override void OnReceived()
    {
        base.OnReceived();

        if (CanUpgrade == false)
            return;

        DurabilityDecreaser.IncreaseDurability(_increaseAmount);
    }
}
