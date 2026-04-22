using System.Collections;
using TMPro;
using UnityEngine;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _value;
    [SerializeField] private Wallet _wallet;

    private int _startValue = 0;

    private void OnEnable()
    {
        _wallet.Changed += OnMoneyChanged;
    }

    private void OnDisable()
    {
        _wallet.Changed -= OnMoneyChanged;
    }

    private void Awake()
    {
        _value.text = _startValue.ToString();
    }

    private void OnMoneyChanged(int amount)
    {
        _value.text = amount.ToString();
    }
}