using System;
using UnityEngine;

public class OrePlacer : MonoBehaviour
{
    [SerializeField] private PlacementZone _placementZone;
    [SerializeField] float objectSpacing = 0.2f;

    [SerializeField] private OreStorage _storage;
    [SerializeField] private OreTracker _tracker;

    private void OnEnable()
    {
        _storage.Collected += OnOreCollected;
    }

    private void OnDisable()
    {
        _storage.Collected -= OnOreCollected;
    }

    private void OnOreCollected(Ore ore)
    {
        if (_tracker.IsDrilled(ore) == false)
            return;

        if(TryPlace(ore) == false)
            return;

        _tracker.AddToCollected(ore);
    }

    private bool TryPlace(Ore ore)
    {
        Vector3 nextPlacePosition = Vector3.zero;

        if (_placementZone.TryGetNextPosition(objectSpacing + ore.transform.localScale.x, out nextPlacePosition) == false)
        {
            return false;
        }
        
        ore.transform.rotation = Quaternion.identity;
        ore.transform.SetParent(transform,false);
        ore.transform.position = nextPlacePosition;
        ore.Rigidbody.isKinematic = true;

        return true;
    }
}