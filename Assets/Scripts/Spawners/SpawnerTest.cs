using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public  class SpawnerTest<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected T Prefab;

    private List<T> _objects = new List<T>();

    protected virtual void OnGet(T obj)
    {
        obj.gameObject.SetActive(true);
        obj.transform.parent = this.transform;
    }

    protected virtual T OnCreate()
    {
        T newObject = Instantiate(Prefab);

        return newObject;
    }

    public void Get()
    {
        T newObject = _objects.FirstOrDefault(obj => obj.isActiveAndEnabled == false);

        if(newObject == null)
            newObject = OnCreate();

        OnGet(newObject);
    }
}