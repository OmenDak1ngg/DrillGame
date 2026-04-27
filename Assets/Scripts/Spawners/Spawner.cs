using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using System.Linq;

public class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected T Prefab;

    private ObjectPool<T> _pool;

    private List<T> _objects = new List<T>();

    protected virtual void Awake()
    {
        _pool = new ObjectPool<T>(
            createFunc:() => OnCreate(),
            actionOnGet:(pooledObject) => OnGet(pooledObject),
            actionOnRelease:(pooledObject) => OnRelease(pooledObject),
            actionOnDestroy:(pooledObject) => OnDestroyObject(pooledObject));
    }

    public virtual void Release(T pooledObject)
    {
        _pool.Release(pooledObject);
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

    public virtual void Get()
    {
        _pool.Get();
    }
}