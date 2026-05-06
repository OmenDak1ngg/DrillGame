using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(Wallet))]
public class Player : MonoBehaviour
{
    [SerializeField] private OreStorage _resourceStorage;

    public Wallet Wallet { get; private set; }
    public OreStorage OreStorage => _resourceStorage;

    private void Awake()
    {
        Wallet = GetComponent<Wallet>();
    }
}