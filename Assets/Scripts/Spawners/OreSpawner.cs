using System;
using UnityEngine;

public class OreSpawner : Spawner<Ore>
{
    [SerializeField] private PlacementZone _placementZone;
    [SerializeField] private float _objectSpacing;

    private Vector3 _SpawnPosition;

    public event Action<Ore> Created;

    protected void Awake()
    {
        _SpawnPosition = Vector3.zero;
    }

    private void Start()
    {
        StartSpawn();
    }

    protected override void OnGet(Ore pooledObject)
    {
        pooledObject.Collider.isTrigger = true;
        pooledObject.Rigidbody.isKinematic = true;
        pooledObject.transform.position = _SpawnPosition;
        pooledObject.transform.SetParent(this.transform);
        base.OnGet(pooledObject);
    }

    protected override Ore OnCreate()
    {
        Ore ore = base.OnCreate();
        Created?.Invoke(ore);

        return ore;
    }

    private void StartSpawn()
    {
        _SpawnPosition = _placementZone.GetStartPosition(1f);
        Get();

        while (_placementZone.TryGetNextPosition(_objectSpacing, out _SpawnPosition))
        {
            Get();
        }
    }
}