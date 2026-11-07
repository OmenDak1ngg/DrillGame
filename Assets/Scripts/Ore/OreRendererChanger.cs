using System;
using System.Collections.Generic;
using UnityEngine;

public class OreRendererChanger : MonoBehaviour
{
    private const int _oreStatesCount = 2;
    private const int _drilledStateIndex = 1;
    private const int _baseStateIndex = 0;

    [SerializeField] private OreTracker _tracker;


    [Tooltip("[0] - baseState; [1] - drilledState")]
    [SerializeField] private Vector3[] _scales = new Vector3[_oreStatesCount];
    [Tooltip("[0] - baseState; [1] - drilledState")]
    [SerializeField] private List<OreData> _materialByType = new List<OreData>();

    public void SetNextState(Ore ore)
    {
        int newStateIndex = _tracker.IsDrilled(ore) ? _drilledStateIndex : _baseStateIndex;

        foreach (OreData oreData in _materialByType)
        {
            if (ore.Type != oreData.Type)
                return;

            Material choosenMaterial;

            if (newStateIndex == 0)
                choosenMaterial = oreData.BaseMaterial;
            else
                choosenMaterial = oreData.DrilledMaterial;

            ore.Renderer.material = choosenMaterial;
            ore.transform.localScale = _scales[newStateIndex];

            return;
        }

        throw new InvalidOperationException("There is no current OreType");
    }
}