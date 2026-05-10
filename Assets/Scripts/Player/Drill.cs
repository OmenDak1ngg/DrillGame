using System;
using UnityEngine;

[RequireComponent(typeof(DurabilityDecreaser))]
[RequireComponent(typeof(Collider))]
public class Drill : MonoBehaviour
{
    private bool _isOreIn;

    private Collider _collider;
    private DurabilityDecreaser _durabilityDecreaser;

    public event Action<Ore> Drilled;

    private void Awake()
    {
        _isOreIn = false;
        _collider = GetComponent<Collider>();
        _durabilityDecreaser = GetComponent<DurabilityDecreaser>();
        _collider.isTrigger = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Ore>(out Ore ore))
        {
            Drilled?.Invoke(ore);
            _durabilityDecreaser.StartDecrease(ore.Durability);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Ore>(out _))
        {
            _durabilityDecreaser.StopDecrease();
        }
    }
}