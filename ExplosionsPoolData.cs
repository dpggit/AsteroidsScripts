using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class ExplosionsPoolData : MonoBehaviour
    {
        [field: SerializeField]
        public int PoolNumber { get; private set; } = 100;

        public List<GameObject> ObjectsInPool = new List<GameObject>();

        public GameObject GetAvailableObjectInPool()
        {
            foreach (GameObject g in ObjectsInPool)
            {
                if (!g.activeInHierarchy) return g;
            }
            return null;
        }
    }
}
