using System;
using UnityEngine;

public class Durability : MonoBehaviour
{
    [SerializeField] private int _amount;

    public event Action ReachedZero;

    public void DecreaseAmount(int value)
    {
        if(value < 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        _amount -= value;

        if(_amount <= 0)
        {
            _amount = 0;
            ReachedZero?.Invoke();
        }
    }
}