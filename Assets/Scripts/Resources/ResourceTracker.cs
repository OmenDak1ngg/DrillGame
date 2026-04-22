using System;
using UnityEngine;

public class ResourceTracker : MonoBehaviour
{
    [SerializeField] private ResourceStorage _resourceStorage;
    [SerializeField] private ResourceSpawner _resourceSpawner;
    [SerializeField] private ResourcePlacer _resourcePlacer;

    private Resource _lastCollectedResource;

    private void OnEnable()
    {
        _resourceStorage.Decreased += OnStorageDecrease;
        _resourceStorage.Collected += OnResourceCollected;        
    }

    private void OnDisable()
    {
        _resourceStorage.Decreased -= OnStorageDecrease;
        _resourceStorage.Collected -= OnResourceCollected;
    }


    private void OnStorageDecrease()
    {
        _resourceSpawner.Release(_lastCollectedResource);
    }

    private void OnResourceCollected(Resource resource)
    {
        _resourcePlacer.TryPlace(resource);
        _lastCollectedResource = resource;  
    }
}