using UnityEngine;

public class SellableItem : Item
{
    [SerializeField] private int _cost;
    public int Cost => _cost;
}
