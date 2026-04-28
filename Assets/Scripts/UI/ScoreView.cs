using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    [SerializeField] private LevelCompletionHandler _completionhandler;

    private float _minSliderValue = 0f;

    private void Awake()
    {
        _slider.minValue = _minSliderValue;
        _slider.maxValue = _completionhandler.MaxScore;
    }

    private void OnEnable()
    {
        _completionhandler.ReachedScore += OnReachedScore;
    }

    private void OnDisable()
    {
        _completionhandler.ReachedScore -= OnReachedScore;
    }

    private void OnReachedScore(int value)
    {
        _slider.value = value;
    }
}