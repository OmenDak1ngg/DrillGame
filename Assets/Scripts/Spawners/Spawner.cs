using UnityEngine;
using UnityEngine.Pool;

public class Spawner<T> : MonoBehaviour where T : MonoBehaviour, ISpawnable
{
    [SerializeField] protected T Prefab;

    private ObjectPool<T> _pool;

    protected virtual void Awake()
    {
        _pool = new ObjectPool<T>(
            createFunc:() => OnCreate(),
            actionOnGet:(pooledObject) => OnGet(pooledObject),
            actionOnRelease:(pooledObject) => OnRelease(pooledObject),
            actionOnDestroy:(pooledObject) => OnDestroyObject(pooledObject));
    }

    protected virtual T OnCreate()
    {
        T newObject = Instantiate(Prefab);
        newObject.transform.parent = this.transform;

        return newObject; 
    }

    protected virtual void OnGet(T pooledObject)
    {
        pooledObject.gameObject.SetActive(true);
    }

    protected virtual void OnRelease(T pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
    }

    protected virtual void OnDestroyObject(T pooledObject)
    {
        Destroy(pooledObject);
    }

    protected virtual void Release(T pooledObject)
    {
        _pool.Release(pooledObject);
    }

    protected virtual void Get()
    {
        _pool.Get();
    }
}