using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject objectToPool;
    [SerializeField] private int amountToPool;
    [SerializeField] private List<GameObject> pooledObjects;

    private void Awake()
    {
        PopulatePool();
    }
    
    private void PopulatePool()
    {
        for (var i = 0; i < amountToPool; i++)
        {
            SpawnObject();
        }
    }

    private GameObject SpawnObject()
    {
        var obj = Instantiate(objectToPool, transform);
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;
    }

    public GameObject GetPooledObject()
    {
        // Cycles through list of game objects and returns one that is not used 
        foreach (var pooledObject in pooledObjects)
        {
            if (pooledObject.activeSelf == false)
            {
                return pooledObject;
            }
        }
        // If all items in list are used, create more pooled objects
        return SpawnObject();
    }
}
