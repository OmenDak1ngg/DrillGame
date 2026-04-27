using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Ore : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private BoxCollider _collider;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;
        _collider = GetComponent<BoxCollider>();
        _collider.isTrigger = true;
    }
}