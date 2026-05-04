using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreStarHandler : MonoBehaviour
{
    [SerializeField] private List<ScoreStar> _stars;
    [SerializeField] private LevelCompletionHandler _levelHandler;

    [SerializeField] private Slider _scoreSlider;

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

    private void SetStarPosition(ScoreStar star, int scoreByStar)
    {
        int halfDivider = 2;
        float sliderLeftBoundX = -_scoreSlider.GetComponent<RectTransform>().rect.width / halfDivider;

        Vector3 newStarPosition = new Vector3(ExtensionMethods.Remap(scoreByStar, 0, _levelHandler.MaxScore
            , sliderLeftBoundX, -sliderLeftBoundX),0,0);

        star.RectTransform.anchoredPosition = newStarPosition;
    }
}