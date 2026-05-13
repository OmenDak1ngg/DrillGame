using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class OreReceiver : MonoBehaviour
{
    [SerializeField] private float _decreasingDelay = 0.5f;

    [SerializeField] private ReceiverZone _receiverZone;
    [SerializeField] private OreTracker _oreTracker;
    [SerializeField] private OreStorage _oreStorage;

    private WaitForSeconds _decreasingWait;
    private Coroutine _coroutine;

    public event Action Received;

    private void OnEnable()
    {
        _receiverZone.PlayerEntered += StartDecreasingResource;
        _receiverZone.PlayerExited += StopDecreasingResource;
    }

    private void OnDisable()
    {
        _receiverZone.PlayerEntered -= StartDecreasingResource;
        _receiverZone.PlayerExited -= StopDecreasingResource;
    }

    private void Awake()
    {
        _decreasingWait = new WaitForSeconds(_decreasingDelay);
    }

    private void StopDecreasingResource()
    {
        if (_coroutine == null)
            return;

        StopCoroutine(_coroutine);
    }

    private void StartDecreasingResource()
    {
        _coroutine = StartCoroutine(DecreaseResource());
    }

    private IEnumerator DecreaseResource()
    {
        while (enabled)
        {
            if (_oreTracker.HasCollectedOres() == false)
            {
                StopCoroutine(_coroutine);
                yield break;
            }

            _oreStorage.TryDecreaseAmount();
            Received?.Invoke(); 

            yield return _decreasingWait;
        }
    }
}