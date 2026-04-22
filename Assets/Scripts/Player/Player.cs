using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(Wallet))]
public class Player : MonoBehaviour
{
    [SerializeField] private ResourceStorage _resourceStorage;

    public Wallet Wallet { get; private set; }
    public ResourceStorage ResourceStorage => _resourceStorage;

    private void Awake()
    {
        Wallet = GetComponent<Wallet>();
    }
}