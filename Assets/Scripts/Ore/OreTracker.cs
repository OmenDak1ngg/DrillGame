using System;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class OreTracker : MonoBehaviour
{
    [SerializeField] private Drill _playerDrill;
    [SerializeField] private OreSpawner _oreSpawner;
    [SerializeField] private ResourceSpawner _resourceSpawner;

    private List<Ore> _ores = new List<Ore>();

    private void OnEnable()
    {
        _playerDrill.Drilled += OnDrilled;
    }


    private void OnDisable()
    {
        _playerDrill.Drilled -= OnDrilled;
    }

    private void OnDrilled(Ore ore)
    {
        ore.gameObject.SetActive(false);
        _resourceSpawner.Get();
        _resourceSpawner.SetSpawnpoint(ore.transform.position);
    }

    public void InitElement(Ore ore)
    {
        _ores.Add(ore);
    }
}