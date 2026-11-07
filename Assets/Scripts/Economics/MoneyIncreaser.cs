using UnityEngine;

[RequireComponent(typeof(OreReceiver))]
public class MoneyIncreaser : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private OreReceiver _receiver;
 
    private void OnEnable()
    {
        _receiver.Received += IncreaseMoney;
    }

    private void OnDisable()
    {
        _receiver.Received -= IncreaseMoney;
    }

    private void Awake()
    {
        _receiver = GetComponent<OreReceiver>();
    }

    private void IncreaseMoney(int amount)
    {
        _wallet.IncreaseAmount(amount);
    }
}
