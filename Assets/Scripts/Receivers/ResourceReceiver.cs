using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ResourceReceiver : MonoBehaviour
{
    [SerializeField] private int _resourceCost = 3;
    [SerializeField] private float _decreasingDelay = 0.5f;
    [SerializeField] private int _resourceDecreaseByDelay = 1;

    [SerializeField] private ReceiverZone _receiverZone;

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
            if (player.ResourceStorage.Amount >= _resourceDecreaseByDelay)
            {
                player.ResourceStorage.TryDecreaseAmount(_resourceDecreaseByDelay);
                player.Wallet.IncreaseAmount(_resourceCost);
            }

            yield return _decreasingWait;
        }
    }
}