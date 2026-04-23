using System;
using System.Collections.Generic;
using UnityEngine;

public class ResourceTracker : MonoBehaviour
{
    [SerializeField] private ResourceStorage _resourceStorage;
    [SerializeField] private ResourceSpawner _resourceSpawner;
    [SerializeField] private ResourcePlacer _resourcePlacer;

    private Stack<Resource> _resources;

    private void Awake()
    {
        _resources = new Stack<Resource>();
    }

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
        _resourceSpawner.Release(_resources.Pop());
    }

    private void OnResourceCollected(Resource resource)
    {
        _resourcePlacer.TryPlace(resource);
        _resources.Push(resource);
    }
}