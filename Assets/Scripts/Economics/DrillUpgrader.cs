using System.Collections;
using UnityEngine;


public class DrillUpgrader : MonoBehaviour
{
    [SerializeField] private DurabilityDecreaser _durabilityDecreaser;

    [SerializeField] private int _upgradeCost = 10;

    private MoneyReceiver _receiver;
    private int _collectedMoney;

    protected bool CanUpgrade;
    protected DurabilityDecreaser DurabilityDecreaser => _durabilityDecreaser;

    protected virtual void OnEnable()
    {
        _receiver.Received += OnReceived;
    }

    protected virtual void OnDisable()
    {
        _receiver.Received -= OnReceived;
    }

    protected virtual void Awake()
    {
        _collectedMoney = 0;
        _receiver = GetComponent<MoneyReceiver>();
    }

    protected virtual void OnReceived()
    {
        _collectedMoney++;

        if (_collectedMoney < _upgradeCost)
        {
            CanUpgrade = false;
            return;
        }

        CanUpgrade = true;

        _collectedMoney %= _upgradeCost;
    }
}