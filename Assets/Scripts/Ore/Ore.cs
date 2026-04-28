using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Ore : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private BoxCollider _collider;
    private Renderer _renderer;

    public Renderer Renderer => _renderer;
    public Collider Collider => _collider;
    public Rigidbody Rigidbody => _rigidbody;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<BoxCollider>();
        _rigidbody.isKinematic = true;
        _collider.isTrigger = true;
    }
}