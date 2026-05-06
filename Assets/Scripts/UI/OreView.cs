using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class OreView : MonoBehaviour
{
    [SerializeField] private OreTracker _tracker;
    [SerializeField] private TextMeshProUGUI _value;

    private void OnEnable()
    {
        _tracker.CountUpdated += UpdateCount;
    }

    private void OnDisable()
    {
        _tracker.CountUpdated -= UpdateCount;
    }

    private void UpdateCount(int value)
    {
        _value.text = value.ToString();
    }
}