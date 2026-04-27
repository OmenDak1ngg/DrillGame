using UnityEngine;

public class OreSpawner : SpawnerTest<Ore>
{
    [SerializeField] private PlacementZone _placementZone;
    [SerializeField] private float _objectSpacing = 0.7f;
    [SerializeField] private OreTracker _oreTracker;

    private Vector3 _SpawnPosition;

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
        pooledObject.transform.position = _SpawnPosition;
        base.OnGet(pooledObject);
    }

    protected override Ore OnCreate()
    {
        Ore ore = base.OnCreate();
        _oreTracker.InitElement(ore);

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