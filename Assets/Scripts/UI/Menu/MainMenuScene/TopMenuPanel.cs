using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TopMenuPanel : MonoBehaviour
{
    [SerializeField] private GemWallet _gemWallet;

    [SerializeField] private TextMeshProUGUI _gemsValue;

    private void OnEnable()
    {
        _gemWallet.CountUpdated += OnGemsChanged;
    }

    private void OnDisable()
    {
        _gemWallet.CountUpdated -= OnGemsChanged;
    }

    private void OnGemsChanged(int obj)
    {
        _gemsValue.text = obj.ToString();
    }
}