using System;
using System.Collections;
using UnityEngine;

public abstract class Receiver : MonoBehaviour
{
    [SerializeField] private float _decreasingDelay = 0.5f;
    [SerializeField] private ReceiverZone _receiverZone;

    protected WaitForSeconds DecreasingWait;
    private Coroutine _coroutine;

    private void OnEnable()
    {
        _receiverZone.PlayerEntered += StartDecreasing;
        _receiverZone.PlayerExited += StopDecreasing;
    }

    private void OnDisable()
    {
        _receiverZone.PlayerEntered -= StartDecreasing;
        _receiverZone.PlayerExited -= StopDecreasing;
    }

    private void Awake()
    {
        DecreasingWait = new WaitForSeconds(_decreasingDelay);
    }

    private void StopDecreasing()
    {
        if (_coroutine == null)
            return;

        StopCoroutine(_coroutine);
    }

    private void StartDecreasing()
    {
        _coroutine = StartCoroutine(DecreaseResource());
    }

    protected abstract IEnumerator DecreaseResource();
}