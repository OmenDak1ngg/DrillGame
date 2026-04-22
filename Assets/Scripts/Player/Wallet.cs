using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _amount;

    public event Action<int> Changed;

    public void IncreaseAmount(int value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        _amount += value;
        
        Changed?.Invoke(_amount);
    }

    public void TryDecreaseAmount(int value)
    {
        if (_amount - value < 0)
            throw new InvalidOperationException();
            
        if(value < 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        _amount -= value;

        Changed?.Invoke(_amount);
    }
}