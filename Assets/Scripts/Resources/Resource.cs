using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Resource : MonoBehaviour, IThrowable, ISpawnable
{
    private Rigidbody _rigidbody;

    public event Action<Resource> Collected;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public Rigidbody GetRigidbody()
    {
        return _rigidbody;
    }

    public void InvokeCollected()
    {
        Collected?.Invoke(this);
    }
}