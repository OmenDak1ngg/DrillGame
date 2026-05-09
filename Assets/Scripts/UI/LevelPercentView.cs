using TMPro;
using UnityEngine;

public class LevelPercentView : MonoBehaviour
{
    private readonly int _valueToPercent = 100;
    private readonly int _minPercent = 0;
    private readonly int _maxPercent = 100;

    [SerializeField] private LevelCompletionHandler _levelComplitionHandler;
    [SerializeField] private Wallet _playerWallet;
    [SerializeField] private TextMeshProUGUI _text;


    private void OnEnable()
    {
        UpdatePercentGameplay();
    }

    private void UpdatePercentGameplay()
    {
        _text.text = (Mathf.Clamp((int)Mathf.Round((float)_playerWallet.Amount / _levelComplitionHandler.MaxScore * _valueToPercent)
            ,_minPercent,_maxPercent).ToString()) + " %";
    }
}
