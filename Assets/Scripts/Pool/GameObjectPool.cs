using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{

    [SerializeField] GameObject pooledObjectPrefabs;
    List<GameObject> pooledObjects;
    [SerializeField] int amountToPool;

    public List<GameObject> GetPooledObjects => pooledObjects;

    public int AmountToPool { get => amountToPool; set => amountToPool = value; }
    
    void Start()
    {
        //InitPool();
    }

    public void InitPool()
    {
        if (amountToPool <= 0) return; 
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObjectPrefabs);

            obj.SetActive(false);
            pooledObjects.Add(obj);
            obj.transform.SetParent(this.transform);
        }
    }

    public void InitPool(GameObject pooledObjectPrefabs, int amountToPool)
    {
        if (amountToPool <= 0) return;
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(pooledObjectPrefabs);

            obj.SetActive(false);
            pooledObjects.Add(obj);
            obj.transform.SetParent(this.transform);
        }
    }

    public GameObject GetPooledObject() 
    { 
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy&& pooledObjects[i]!=null)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    internal void RemoveGO(GameObject pooledProjectile)
    {
        pooledObjects.Remove(pooledProjectile);
        Destroy(pooledProjectile.gameObject, 0.2f);
    }
}
