using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ReceiverZone : MonoBehaviour
{
    private BoxCollider _collider;

    public event Action<Player> PlayerEntered;
    public event Action PlayerExited;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider>();
        _collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Player>(out Player player))
            PlayerEntered?.Invoke(player);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent<Player>(out _)) 
            PlayerExited?.Invoke();
    }
}