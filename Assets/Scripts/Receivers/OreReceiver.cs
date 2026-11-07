using System;
using System.Collections;
using UnityEngine;

public class OreReceiver : Receiver
{
    [SerializeField] private OreTracker _oreTracker;
    [SerializeField] private OreStorage _oreStorage;

    public event Action<int> Received;

    protected override IEnumerator DecreaseResource()
    {
        while (enabled)
        {
            if (_oreTracker.HasCollectedOres() == false)         
                yield break;

            Received?.Invoke(_oreTracker.PeekLastCollected().Cost); 
            _oreStorage.TryDecreaseAmount();

            yield return DecreasingWait;
        }
    }
}