using System;
using System.Collections.Generic;
using UnityEngine;

public class OreTracker : MonoBehaviour
{
    [SerializeField] private Drill _drill;
    [SerializeField] private OreRendererChanger _rendererChanger;
    [SerializeField] private Thrower _thrower;
    [SerializeField] private OreSpawner _spawner;
    [SerializeField] private OreStorage _oreStorage;

    private List<Ore> _undrilledOres = new List<Ore>();
    private Stack<Ore> _drilledOres = new Stack<Ore>();
    private Stack<Ore> _collectedOres = new Stack<Ore>();

    private void OnEnable()
    {
        _drill.Drilled += OnDrilled;
        _spawner.Created += OnCreated;
        _oreStorage.Decreased += OnDecreased;
    }

    private void OnDisable()
    {
        _drill.Drilled -= OnDrilled;
        _spawner.Created -= OnCreated;
        _oreStorage.Decreased -= OnDecreased;
    }

    private void OnCreated(Ore ore)
    {
        _undrilledOres.Add(ore);
    }

    private void OnDecreased()
    {
        if (_drilledOres.Count == 0)
            return;

        _drilledOres.Pop().gameObject.SetActive(false);
    }

    private void OnDrilled(Ore ore)
    {
        ore.Collider.isTrigger = false;
        _undrilledOres.Remove(ore);
        _drilledOres.Push(ore);

        _rendererChanger.SetNextState(ore);

        _thrower.ThrowTo(ore, _drill.transform.position);
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
    }

    public void PopFromCollected()
    {
        _collectedOres.Pop();
    }

    public bool IsHasCollectedOres()
    {
        return _collectedOres.Count != 0;
    }
}