using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class LevelCompletionHandler : MonoBehaviour
{
    [SerializeField] private List<int> _scoreGoals;
    [SerializeField] private Wallet _playerWallet;

    public int LastGettedGoalIndex { get; private set; }

    public int MaxScore => _scoreGoals.Max();
    public List<int> ScoreGoals => _scoreGoals;

    public event Action<int> ReachedScore;
    public event Action ReachedAnyGoal;

    private void Awake()
    {
        _scoreGoals.Sort();
        LastGettedGoalIndex = 0;
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

        for(int i = _scoreGoals.Count - 1; i >= 0; i--)
        {
            int score = _scoreGoals[i];

            if (value >= score)
            {
                ReachedAnyGoal?.Invoke();
                LastGettedGoalIndex = _scoreGoals.IndexOf(score);
                Debug.Log($"{LastGettedGoalIndex} {score}");

                return;
            }
        }
    }
}
