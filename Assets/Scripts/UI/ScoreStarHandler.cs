using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreStarHandler : MonoBehaviour
{
    [SerializeField] private List<ScoreStar> _stars;
    [SerializeField] private LevelCompletionHandler _levelHandler;

    [SerializeField] private Slider _scoreSlider;

    [SerializeField] private float _xOffset;

    private Dictionary<ScoreStar, int> _starToScoreGoal = new Dictionary<ScoreStar, int>();

    private void OnEnable()
    {
        _levelHandler.ReachedScore += OnScoreReached;
    }

    private void OnDisable()
    {
        _levelHandler.ReachedScore -= OnScoreReached;
    }

    private void Awake()
    {
        if (_stars.Count != _levelHandler.ScoreGoals.Count)
            throw new ArgumentOutOfRangeException();
    }

    private void Start()
    {
        for (int i = 0; i < _stars.Count; i++)
        {
            SetStarPosition(_stars[i], _levelHandler.ScoreGoals[i]);
        }
    }

    private void OnScoreReached(int value)
    {
        foreach(ScoreStar star in _starToScoreGoal.Keys)
        {
            if(value >= _starToScoreGoal[star])
            {
                star.SetActive();
            }
        }
    }

    private void SetStarPosition(ScoreStar star, int scoreByStar)
    {
        int halfDivider = 2;
        float sliderLeftBoundX = -_scoreSlider.GetComponent<RectTransform>().rect.width / halfDivider;

        Vector3 newStarPosition = new Vector3(ExtensionMethods.Remap(scoreByStar, 0, _levelHandler.MaxScore
            , sliderLeftBoundX, -sliderLeftBoundX) + _xOffset,0,0);

        star.RectTransform.anchoredPosition = newStarPosition;
        _starToScoreGoal.Add(star, scoreByStar);
    }
}