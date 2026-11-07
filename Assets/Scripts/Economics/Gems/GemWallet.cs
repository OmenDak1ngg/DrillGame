using System;
using UnityEngine;

public class GemWallet : MonoBehaviour
{
    private int _count;

    public event Action<int> CountUpdated;

    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.Save();
    
        _count = GemsData.GetCurrentDiamonds();
        CountUpdated?.Invoke(_count);

    }

    public bool TryDecreaseCount(int decreaseCount)
    {
        if (_count - decreaseCount < 0)
            throw new ArgumentOutOfRangeException();

        _count -= decreaseCount;
        GemsData.SaveDiamondsCount(_count);
        CountUpdated?.Invoke(_count);

        return true;
    }
}
