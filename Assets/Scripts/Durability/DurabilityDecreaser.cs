using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class DurabilityDecreaser : MonoBehaviour
{
    [SerializeField] private int _decreaseAmount = 2;

    [SerializeField] private float _decreaseDelay = 1;

    private WaitForSeconds _decreaseWait;
    private Coroutine _coroutine;

    private void Awake()
    {
        _decreaseWait = new WaitForSeconds(_decreaseDelay);
    }

    private IEnumerator Decrease(Durability durability)
    {
        while (enabled)
        {
            yield return _decreaseWait;
            
            durability.DecreaseAmount(_decreaseAmount);
        }
    }

    public void StartDecrease(Durability durability)
    {
        if (_coroutine != null)
            return;

        _coroutine = StartCoroutine(Decrease(durability));
    }

    public void StopDecrease()
    {
        if (_coroutine == null)
            return;

        StopCoroutine(_coroutine);
        _coroutine = null;
    }
}