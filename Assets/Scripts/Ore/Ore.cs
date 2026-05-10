using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Durability))]
public class Ore : MonoBehaviour
{
    public Durability Durability { get; private set; }
    public Renderer Renderer { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    public Collider Collider { get; private set; }

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