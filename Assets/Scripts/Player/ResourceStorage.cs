using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ResourceStorage : MonoBehaviour
{
    [SerializeField] private int _maxAmount = 20;
    [SerializeField] private ResourcePlacer _placer;

    private int _amount;

    private void Awake()
    {
        GetComponent<BoxCollider>().isTrigger = true;   
        _amount = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Resource>(out Resource resource))
        {
            if (_amount >= _maxAmount)
                return;

            _amount++;
            _placer.TryPlace(resource);
            //resource.InvokeCollected();
        }
    }

    public void TryDecreaseAmount(int amount)
    {
        if(_amount - amount < 0)
            return;

        _amount -= amount;
    }
}