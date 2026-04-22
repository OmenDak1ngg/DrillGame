using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ResourceStorage : MonoBehaviour
{
    [SerializeField] private int _maxAmount = 20;

    private int _amount;

    public int Amount => _amount;

    public event Action<Resource> Collected;
    public event Action Decreased;

    private void Awake()
    {
        GetComponent<BoxCollider>().isTrigger = true;   
        _amount = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Resource>(out Resource resource))
        {
            if (_amount >= _maxAmount)
                return;

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