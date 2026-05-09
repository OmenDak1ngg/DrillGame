using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelCompletionHandler : MonoBehaviour
{
    [SerializeField] private List<int> _scoreGoals;
    [SerializeField] private Wallet _playerWallet;

    public int MaxScore => _scoreGoals.Max();
    public List<int> ScoreGoals => _scoreGoals;

    public event Action<int> ReachedScore;
    public event Action ReachedAnyGoal;

    private void Awake()
    {
        _scoreGoals.Sort();
    }

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
        
        foreach(int  score in _scoreGoals)
        {
            if(value >= score)
            {
                ReachedAnyGoal?.Invoke();
                
                return;
            }
        }

    }
}
