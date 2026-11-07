using System;
using System.Collections;
using UnityEngine;


public class MoneyReceiver : Receiver
{
    [SerializeField] private Wallet _wallet;

    private int _countOfDecrease = 1;

    public event Action Received;

    protected override IEnumerator DecreaseResource()
    {
        while (enabled)
        {
            if (_wallet.Amount == 0)
                yield break;

            _wallet.TryDecreaseAmount(_countOfDecrease);
            Received?.Invoke();

            yield return DecreasingWait;
        }
    }
}