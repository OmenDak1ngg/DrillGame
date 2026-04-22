using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Drill : MonoBehaviour
{
    private Collider _collider;

    public event Action<Ore> Drilled;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _collider.isTrigger = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Ore>(out Ore ore))
            Drilled?.Invoke(ore);
    }
}