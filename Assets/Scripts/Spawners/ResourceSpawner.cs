using UnityEngine;

public class ResourceSpawner : Spawner<Resource>
{
    [SerializeField] private Transform _target;
    [SerializeField] private ResourceThrower _thrower;

    private Vector3 _spawnpoint;

    public void SetSpawnpoint(Vector3 newSpawnpoint)
    {
        _spawnpoint = newSpawnpoint + new Vector3(0, 0.5f, 0);
    }

    protected override Resource OnCreate()
    {
        Resource resource = base.OnCreate();

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
}