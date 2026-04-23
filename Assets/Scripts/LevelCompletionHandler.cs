using System;
using System.Linq;
using UnityEngine;

public class LevelCompletionHandler : MonoBehaviour
{
    [SerializeField] private int[] _scoreGoals = new int[3];
    [SerializeField] private Wallet _playerWallet;

    public int MaxScore => _scoreGoals.Max();

    public event Action<int> ReachedScore;

    private void OnEnable()
    {
        _playerWallet.Changed += OnWalletUpdate;
    }

    private void OnDisable()
    {
        _playerWallet.Changed -= OnWalletUpdate;
    }

    private void OnWalletUpdate(int value)
    {
        ReachedScore.Invoke(value);
    }
}
