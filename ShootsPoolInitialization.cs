using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class ShootsPoolInitialization : MonoBehaviour
    {
        [SerializeField]
        private GameObject poolPrefab;

        private ShootsPoolData shootsPoolData;

        private void Awake()
        {
            shootsPoolData = GetComponent<ShootsPoolData>();
        }

        //Create a pool of shoots, disable them and set them as children of this object
        public void StartPool()
        {
            GameObject obj = null;
            for (int i = 0; i < shootsPoolData.PoolNumber; i++)
            {
                obj = Instantiate(poolPrefab);
                obj.SetActive(false);
                shootsPoolData.ObjectsInPool.Add(obj);
                obj.transform.SetParent(transform);
            }
        }
    }
}
