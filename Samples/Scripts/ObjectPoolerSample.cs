using System.Collections.Generic;
using UnityEngine;

namespace Monomite.Samples
{
    public class ObjectPoolerSample : MonoBehaviour
    {
        #region Singleton
        public static ObjectPoolerSample Instance
        {
            get;
            private set;
        }
        private void CreateSingleton()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
        }
        #endregion

        private void Awake()
        {
            CreateSingleton();
        }

        [SerializeField]
        private GameObject ObjectToPool;

        [SerializeField]
        private int PoolQuantity;

        private List<GameObject> PooledObjects;

        private void Start()
        {
            PooledObjects = new List<GameObject>();

            GameObject obj;
            for (int i = 0; i < PoolQuantity; i++)
            {
                obj = GameObject.Instantiate(ObjectToPool);
                obj.SetActive(false);
                PooledObjects.Add(obj);
            }
        }

        public GameObject GetPooledObject()
        {
            foreach (GameObject pooledObject in PooledObjects)
            {
                if (!pooledObject.activeInHierarchy)
                {
                    return pooledObject;
                }
            }

            return null;
        }

        public void DisableObjects()
        {
            foreach (GameObject pooledObject in PooledObjects)
            {
                if (pooledObject.activeInHierarchy)
                {
                    pooledObject.SetActive(false);
                }
            }
        }
    }
}