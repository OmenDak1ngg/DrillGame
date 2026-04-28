using System.Collections.Generic;
using UnityEngine;

public class OreTracker : MonoBehaviour
{
    private List<Ore> _undrilledOres = new List<Ore>();
    private Stack<Ore> _drilledOres = new Stack<Ore>();
     
    public void RemoveFromDrilled(Ore ore)
    {
        _undrilledOres.Remove(ore);
    }

    public Ore PopFromDrilled()
    {
        return _drilledOres.Pop();
    }

    public void PushToDrilled(Ore ore)
    {
        _drilledOres.Push(ore);
    }

    public void AddToUndrilled(Ore ore)
    {
        _undrilledOres.Add(ore);
    }

    public bool IsDrilled(Ore ore)
    {
        return _drilledOres.Contains(ore);
    }
}