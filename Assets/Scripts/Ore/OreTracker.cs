using System;
using System.Collections.Generic;
using UnityEngine;

public class OreTracker : MonoBehaviour
{
    [SerializeField] private Drill _drill;
    [SerializeField] private OreRendererChanger _rendererChanger;
    [SerializeField] private Thrower _thrower;
    [SerializeField] private OreStorage _oreStorage;

    private Stack<Ore> _drilledOres = new Stack<Ore>();
    private Stack<Ore> _collectedOres = new Stack<Ore>();

    public event Action<int> CountUpdated;

    private void OnEnable()
    {
        _drill.Drilled += OnDrilled;
        _oreStorage.Decreased += OnDecreased;
    }

    private void OnDisable()
    {
        _drill.Drilled -= OnDrilled;
        _oreStorage.Decreased -= OnDecreased;
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
        CountUpdated?.Invoke(_collectedOres.Count);
    }

    public bool HasCollectedOres()
    {
        return _collectedOres.Count > 0;
    }
}