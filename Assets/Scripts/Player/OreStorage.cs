using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class OreStorage : MonoBehaviour
{
    [SerializeField] private PlacementZone _placementZone;
    
    public event Action<Ore> Collected;
    public event Action Decreased;

    private void Awake()
    {
        GetComponent<BoxCollider>().isTrigger = true;   
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Ore>(out Ore resource))
        {
            Collected?.Invoke(resource);
        }
    }

    public void TryDecreaseAmount()
    {
        Decreased?.Invoke();
        _placementZone.SetPreviousCurrentPosition();
    }
}