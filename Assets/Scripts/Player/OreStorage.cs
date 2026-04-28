using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class OreStorage : MonoBehaviour
{
    private int _amount;

    public int Amount => _amount;

    public event Action<Ore> Collected;
    public event Action Decreased;

    private void Awake()
    {
        GetComponent<BoxCollider>().isTrigger = true;   
        _amount = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Ore>(out Ore resource))
        {
            Collected?.Invoke(resource);
            _amount++;
        }
    }

    public void TryDecreaseAmount(int amount)
    {
        if(_amount - amount < 0)
            return;

        _amount -= amount;
        Decreased?.Invoke();
    }
}