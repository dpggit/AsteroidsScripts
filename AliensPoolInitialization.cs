using Asteroids;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class AliensPoolInitialization : MonoBehaviour
    {
        [SerializeField]
        private GameObject poolPrefab;
        [SerializeField]
        private PlayerInitialization playerInitialization;
        [SerializeField]
        private CameraManager cameraManager;

        private AliensPoolData aliensPoolData;
        private AliensPoolMovement aliensPoolMovement;

        void Start()
        {
            aliensPoolData = GetComponent<AliensPoolData>();
            aliensPoolMovement = GetComponent<AliensPoolMovement>();
            StartCoroutine(WaitOneFrameStartPool());
        }

        IEnumerator WaitOneFrameStartPool()
        {
            yield return null;
            StartPool();
        }

        private void StartPool()
        {
            GameObject alienObj = null;
            for (int i = 0; i < aliensPoolData.PoolNumber; i++)
            {
                alienObj = Instantiate(poolPrefab);
                alienObj.SetActive((i > aliensPoolData.SpawnedNumber - 1) ? false : true);
                alienObj.transform.position = RandomStartingPosInViewport();
                alienObj.GetComponent<Alien>().Direction = aliensPoolMovement.Random2DDirection();
                alienObj.transform.SetParent(transform);
                aliensPoolData.ObjectsInPool.Add(alienObj);
            }
        }

        //The starting viewport coordinates to be translated to world coordinates 
        private Vector3 RandomStartingPosInViewport()
        {
            Vector3 alienPosition = RandomStartingAlienPosition(new Vector2(0.5f, 0.5f), Random.Range(0.4f, 0.5f), 10);
            return cameraManager.MainCamera.ViewportToWorldPoint(new Vector3(alienPosition.x, alienPosition.y, playerInitialization.PlayerViewport.z));
        }

        Vector2 RandomStartingAlienPosition(Vector2 center, float radius, int subdivisions)
        {
            Vector2[] aliensPositions = new Vector2[subdivisions];
            for (int i = 0; i < subdivisions; i++)
            {
                float angle = (float)(i + 1) / (float)subdivisions * Mathf.PI * 2.0f;
                aliensPositions[i] = center + new Vector2(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius);
            }
            return aliensPositions[Random.Range(0, subdivisions - 1)];
        }

        public void ReinitializePool()
        {
            for (int i = 0; i < aliensPoolData.ObjectsInPool.Count; i++)
            {
                GameObject alien = aliensPoolData.ObjectsInPool[i];
                alien.transform.position = RandomStartingPosInViewport();
                alien.GetComponent<Alien>().Direction = aliensPoolMovement.Random2DDirection();
                alien.SetActive(false);
            }
        }
    }
}
