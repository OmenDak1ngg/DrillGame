using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class OreData : MonoBehaviour
{
    [SerializeField] private OreType _type;
    [SerializeField] private Material _baseMaterial;
    [SerializeField] private Material _drilledMaterial;

    public OreType Type => _type;
    public Material BaseMaterial => _baseMaterial;
    public Material DrilledMaterial => _drilledMaterial;
}
