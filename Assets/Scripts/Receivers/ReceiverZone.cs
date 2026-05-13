using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ReceiverZone : MonoBehaviour
{
    private BoxCollider _collider;

    private bool _isPlayerEntered;

    public event Action PlayerEntered;
    public event Action PlayerExited;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider>();
        _collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Player>(out Player player))
        {
            if (_isPlayerEntered)
                return;

            _isPlayerEntered = true;
            PlayerEntered?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out _))
        {
            if (_isPlayerEntered == false)
                return;

            _isPlayerEntered = false;
            PlayerExited?.Invoke();
        }
    }
}