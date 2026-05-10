using System;
using System.Collections.Generic;
using UnityEngine;

public class OreTracker : MonoBehaviour
{
    [SerializeField] private OreSpawner _spawner;
    [SerializeField] private OreRendererChanger _rendererChanger;
    [SerializeField] private Thrower _thrower;
    [SerializeField] private OreStorage _oreStorage;

    private Stack<Ore> _drilledOres = new Stack<Ore>();
    private Stack<Ore> _collectedOres = new Stack<Ore>();

    private List<Ore> _ores  = new List<Ore>();

    public event Action<int> CountUpdated;

    private void OnEnable()
    {
        _spawner.Created += (ore) => _ores.Add(ore);
        _oreStorage.Decreased += OnDecreased;

        foreach(Ore ore in _ores)
        {
            ore.Destroyed += OnDrilled;
        }
    }

    private void OnDisable()
    {
        _spawner.Created -= (ore) => _ores.Remove(ore); 
        _oreStorage.Decreased -= OnDecreased;
    
        foreach(Ore ore in _ores)
        {
            ore.Destroyed -= OnDrilled;
        }
    }

    private void OnDecreased()
    {
        if (_collectedOres.Count == 0)
            return;

        Ore decreasedOre = _collectedOres.Pop();
        CountUpdated?.Invoke(_collectedOres.Count);
        decreasedOre.gameObject.SetActive(false);
        decreasedOre.transform.SetParent(null);
    }

    private void OnDrilled(Ore ore)
    {
        ore.Collider.isTrigger = false;
        _drilledOres.Push(ore);

        _rendererChanger.SetNextState(ore);

        _thrower.ThrowTo(ore, _oreStorage.transform.position);
    }

    public Ore PopFromDrilled()
    {
        return _drilledOres.Pop();
    }

    public bool IsDrilled(Ore ore)
    {
        return _drilledOres.Contains(ore);
    }

    public void AddToCollected(Ore ore)
    {
        _collectedOres.Push(ore);
        CountUpdated?.Invoke(_collectedOres.Count);
    }

    public bool HasCollectedOres()
    {
        return _collectedOres.Count > 0;
    }
}