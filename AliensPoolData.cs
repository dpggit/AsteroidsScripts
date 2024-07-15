using Asteroids;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroids
{
    public class AliensPoolData : MonoBehaviour
    {
        [field:SerializeField]
        public int PoolNumber { get; private set; } = 100;
        [field: SerializeField]
        public int SpawnedNumber { get; private set; } = 10;
        [field: SerializeField]
        public float ShootingFrequency { get; private set; } = 3f;
        [field: SerializeField]
        public float ShootMaxDistance { get; private set; } = 100f;
        [field: SerializeField]
        public float ShootSpeed { get; private set; } = 10f;
        //Seconds that must pass before can spawn again
        [field: SerializeField]
        public float SpawnDelay { get; private set; } = 5f;
        //Range from 0 to 1, the lower the higher chance an alien spawns. This value is modified in code, the higher the level wave is the more likely is to spawn
        [field: SerializeField]
        public float ChanceToFailToSpawn { get; private set; } = 0.9f;
        //Range from 0 to 1, the lower the higher chance the alien changes of direction
        [field: SerializeField]
        public float ChanceToFailChangingDirection { get; private set; } = 0.7f;
        //Range from 0 to 1, the lower the higher chance to target well the player when attacks
        [field: SerializeField]
        public float ChanceToFailTargetPlayer { get; private set; } = 0.5f;

        [HideInInspector]
        public bool RestartingNewLevel;

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
