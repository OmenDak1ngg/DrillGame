using UnityEngine;

[RequireComponent(typeof(OreReceiver))]
public class DrillUpgrader : MonoBehaviour
{
    [SerializeField] private DurabilityDecreaser _durabilityDecreaser;

    [SerializeField] private int _upgradeCost = 10;
    [SerializeField] private int _upgradeAmount = 1;

    private OreReceiver _receiver;

    private int _oreCount;

    private void OnEnable()
    {
        _receiver.Received += UpgradeDecreaser;
    }

    private void OnDisable()
    {
        _receiver.Received -= UpgradeDecreaser;
    }

    private void Awake()
    {
        _oreCount = 0;
        _receiver = GetComponent<OreReceiver>();
    }

    private void UpgradeDecreaser()
    {
        _oreCount++;

        if(_oreCount == _upgradeCost)
        {
            Debug.Log("Upgraded");
            _durabilityDecreaser.IncreaseAmount(_upgradeAmount);

            _oreCount %= _upgradeCost;
        }
    }
}
