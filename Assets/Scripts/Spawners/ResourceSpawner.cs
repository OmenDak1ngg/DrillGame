using UnityEngine;

public class ResourceSpawner : Spawner<Resource>
{
    [SerializeField] private Transform _target;
    [SerializeField] private OreTracker _oreTracker;
    [SerializeField] private ResourceThrower _thrower;

    private Vector3 _spawnpoint;

    private void OnEnable()
    {
        _oreTracker.SubscribeElements(ore => SetSpawnpoint(ore.transform.position));
        _oreTracker.SubscribeElements(ore => Get());
    }

    private void OnDisable()
    {
        _oreTracker.UnSubscribeElements(ore => SetSpawnpoint(ore.transform.position));
        _oreTracker.UnSubscribeElements(ore => Get());
    }

    private void Start()
    {
        _oreTracker.SubscribeElements(ore => SetSpawnpoint(ore.transform.position));
        _oreTracker.SubscribeElements(ore => Get());
    }

    protected override Resource OnCreate()
    {
        Resource resource = base.OnCreate();
        resource.Collected += Release;

        return resource;
    }

    protected override void OnGet(Resource pooledResource)
    {
        pooledResource.GetRigidbody().isKinematic = false;
        pooledResource.transform.parent = this.transform;
        pooledResource.transform.position = _spawnpoint;
        _thrower.ThrowTo(pooledResource, _target.transform.position);
        base.OnGet(pooledResource);
    }

    private void SetSpawnpoint(Vector3 newSpawnpoint)
    {
        _spawnpoint = newSpawnpoint + new Vector3(0, 0.5f, 0);
    }
}