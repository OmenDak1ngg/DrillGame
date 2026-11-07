using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Durability))]
public class Ore : MonoBehaviour
{
    [SerializeField] private int _cost = 2;
    [SerializeField] private OreType _type;

    public Durability Durability { get; private set; }
    public Renderer Renderer { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    public Collider Collider { get; private set; }

    public OreType Type => _type; 
    public int Cost => _cost;

    public event Action<Ore> Destroyed;

    private void OnEnable()
    {
        Durability.ReachedZero += () => Destroyed?.Invoke(this);
    }

    private void OnDisable()
    {
        Durability.ReachedZero -= () => Destroyed?.Invoke(this);    
    }

    private void Awake()
    {
        Renderer = GetComponent<Renderer>();
        Rigidbody = GetComponent<Rigidbody>();
        Durability = GetComponent<Durability>();
        Collider = GetComponent<Collider>();
        Collider.isTrigger = false;
        Rigidbody.isKinematic = true;
    }
}