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

        for(int i = 0; i < _stars.Count; i++)
        {
            SetStarPosition(_stars[i], _levelHandler.ScoreGoals[i]);
        }
    }

    private void SetStarPosition(ScoreStar star, int ScoreByStar)
    {
        int halfDivider = 2;
        float sliderLeftBoundX = -_scoreSlider.GetComponent<RectTransform>().rect.x / halfDivider;

        Vector3 newStarPosition = new Vector3(ExtensionMethods.Remap(star.RectTransform.position.x, 0, _levelHandler.MaxScore
            , sliderLeftBoundX, -sliderLeftBoundX),0,0);

        Debug.Log(newStarPosition);

        star.RectTransform.position = newStarPosition;
    }
}