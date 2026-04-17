using UnityEngine;

public class OreSpawner : Spawner<Ore>
{
    [SerializeField] private PlacementZone _placementZone;
    [SerializeField] private float _spaceBetweenObjects = 0.2f;
    [SerializeField] private OreTracker _oreTracker;

    private float _objectSpacing;

    private float _oreSize;
    private Vector3 _SpawnPosition;

    private void OnEnable()
    {
        _oreTracker.SubscribeElements(Release);
    }

    private void OnDisable()
    {
        _oreTracker.UnSubscribeElements(Release);
    }

    protected override void Awake()
    {
        base.Awake();
        _SpawnPosition = Vector3.zero;
        _oreSize = Prefab.GetSize();
        _objectSpacing = _spaceBetweenObjects + _oreSize;
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
        _oreTracker.InitElement(ore, Release);

        return ore;
    }

    private void StartSpawn()
    {
        _SpawnPosition = _placementZone.GetStartPosition(_oreSize);
        Get();

        while (_placementZone.TryGetNextPosition(_objectSpacing, out _SpawnPosition))
        {
            Get();
        }
    }
}