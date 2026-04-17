using System;
using System.Collections.Generic;
using UnityEngine;

public class OreTracker : MonoBehaviour
{
    private List<Ore> _ores;

    private bool _canSubscribe => _ores != null;

    private void Awake()
    {
        _ores = new List<Ore>();
    }

    public void InitElement(Ore ore, Action<Ore> action)
    {
        ore.Drilled += action;
        _ores.Add(ore);
    }

    public void SubscribeElements(Action<Ore> action)
    {
        if (_canSubscribe == false)
            return;

        foreach (Ore ore in _ores)
        {
            ore.Drilled += action;
        }
    }

    public void UnSubscribeElements(Action<Ore> action)
    {
        foreach (Ore ore in _ores)
        {
            ore.Drilled -= action;
        }
    }
}