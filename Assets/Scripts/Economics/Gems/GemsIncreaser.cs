using System;
using System.Collections.Generic;
using UnityEngine;

public class GemsIncreaser : MonoBehaviour
{
    [SerializeField] private EndLevelButton _endLevelButton;
    [SerializeField] private LevelCompletionHandler _levelHandler;

    [SerializeField] private List<int> _gemsReward = new List<int>();

    private void OnEnable()
    {
        _endLevelButton.OnLevelEnded += IncreaseDiamonds;
    }

    private void OnDisable()
    {
        _endLevelButton.OnLevelEnded -= IncreaseDiamonds;
    }

    private void Awake()
    {
        _gemsReward.Sort();
    }

    private void IncreaseDiamonds()
    {
        if(_levelHandler.LastGettedGoalIndex > _gemsReward.Count)
            throw new IndexOutOfRangeException();

        GemsData.TryIncreaseDiamondsCount(_gemsReward[_levelHandler.LastGettedGoalIndex]);
    }
}