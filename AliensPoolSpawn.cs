using Asteroids;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class AliensPoolSpawn : MonoBehaviour
    {
        [SerializeField]
        private GameData gameData;
        [SerializeField]
        private PlayerInitialization playerInitialization;

        private AliensPoolData aliensPoolData;
        private float lastTimeAppeared;

        void Start()
        {
            aliensPoolData = GetComponent<AliensPoolData>();
        }

        public void CheckIfSpawnAlien()
        {
            if (Mathf.PerlinNoise(0, Time.time + 1000f) > aliensPoolData.ChanceToFailToSpawn - gameData.WaveLevel * 0.1f && Time.time > lastTimeAppeared + aliensPoolData.SpawnDelay)
            {
                lastTimeAppeared = Time.time;
                GameObject alienObj = aliensPoolData.GetAvailableObjectInPool();
                alienObj.transform.position = new Vector3(alienObj.transform.position.x, playerInitialization.transform.position.y, alienObj.transform.position.z);
                alienObj.SetActive(true);
            }
        }
    }
}
