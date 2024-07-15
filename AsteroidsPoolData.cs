using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class AsteroidsPoolData : MonoBehaviour
    {
        [field: SerializeField]
        public int PoolNumber { get; private set; } = 100;
        [field: SerializeField]
        public int Life { get; private set; } = 150;
        public int SpawnedNumber = 10;
        [field: SerializeField]
        public int Subdivisions { get; private set; } = 2;
        [field: SerializeField]
        public float SpeedIncrementInSubdivisions { get; private set; } = 5f;

        [HideInInspector]
        public bool RestartingNewLevel;
        [HideInInspector]
        public int OriginalSpawnNumber;

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
