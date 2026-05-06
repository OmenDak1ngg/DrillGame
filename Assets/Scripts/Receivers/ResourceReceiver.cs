using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ResourceReceiver : MonoBehaviour
{
    [SerializeField] private int _resourceCost = 3;
    [SerializeField] private float _decreasingDelay = 0.5f;

    [SerializeField] private ReceiverZone _receiverZone;
    [SerializeField] private OreTracker _oreTracker;

    private WaitForSeconds _decreasingWait;
    private Coroutine _coroutine;

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

    private void StartDecreasingResource(Player player)
    {
        _coroutine = StartCoroutine(DecreaseResource(player));
    }

    private IEnumerator DecreaseResource(Player player)
    {
        while (enabled)
        {
            if (_oreTracker.HasCollectedOres() == false)
            {
                StopCoroutine(_coroutine);
                yield break;
            }

            player.OreStorage.TryDecreaseAmount();
            player.Wallet.IncreaseAmount(_resourceCost);

            yield return _decreasingWait;
        }
    }
}