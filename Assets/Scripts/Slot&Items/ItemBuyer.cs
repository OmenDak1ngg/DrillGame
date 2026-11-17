using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class ItemBuyer : MonoBehaviour
{
    [SerializeField] private GemWallet _gemWallet;

    private bool TryBuyItem(SellableItem item)
    {
        if (_gemWallet.Count >= item.Cost)
            return true;

        return false;
    }
}
