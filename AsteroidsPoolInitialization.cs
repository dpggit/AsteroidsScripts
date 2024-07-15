using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class AsteroidsPoolInitialization : MonoBehaviour
    {
        [SerializeField]
        private GameReset gameReset;
        [SerializeField]
        private GameObject poolPrefab;
        [SerializeField]
        private CameraManager cameraManager;
        [SerializeField]
        private PlayerInitialization playerInitialization;

        private AsteroidsPoolData asteroidsPoolData;
        private AsteroidsPoolMovement asteroidsPoolMovement;

        void Start()
        {
            StartCoroutine(WaitOneFrameStartPool());
        }

        void OnEnable()
        {
            asteroidsPoolData = GetComponent<AsteroidsPoolData>();
            asteroidsPoolMovement = GetComponent<AsteroidsPoolMovement>();
            asteroidsPoolData.OriginalSpawnNumber = asteroidsPoolData.SpawnedNumber;
        }

        IEnumerator WaitOneFrameStartPool()
        {
            yield return null;
            StartPool();
        }

        private void StartPool()
        {
            GameObject asteroidObj = null;
            for (int i = 0; i < asteroidsPoolData.PoolNumber; i++)
            {
                asteroidObj = Instantiate(poolPrefab);
                asteroidObj.SetActive((i > asteroidsPoolData.SpawnedNumber - 1) ? false : true);
                asteroidObj.transform.position = RandomStartingPosInViewport();
                asteroidObj.GetComponent<Asteroid>().Direction = asteroidsPoolMovement.Random2DDirection();
                asteroidObj.GetComponent<Asteroid>().Life = asteroidsPoolData.Life;
                asteroidObj.transform.SetParent(transform);
                asteroidsPoolData.ObjectsInPool.Add(asteroidObj);
            }
        }

        public void ReinitializePool()
        {
            for (int i = 0; i < asteroidsPoolData.ObjectsInPool.Count; i++)
            {
                GameObject asteroidObj = asteroidsPoolData.ObjectsInPool[i];
                Asteroid asteroidComp = asteroidObj.GetComponent<Asteroid>();
                asteroidObj.SetActive((i > asteroidsPoolData.SpawnedNumber - 1) ? false : true);
                asteroidObj.transform.localScale = Vector3.one;
                asteroidObj.transform.position = RandomStartingPosInViewport();
                asteroidComp.Speed = asteroidComp.BaseSpeed;
                asteroidComp.Direction = asteroidsPoolMovement.Random2DDirection();
                asteroidComp.Life = asteroidsPoolData.Life;
            }
        }

        public void Spawn(Asteroid asteroidParent)
        {
            GameObject asteroid = asteroidsPoolData.GetAvailableObjectInPool();
            if (asteroid != null)
            {
                Asteroid asteroidComp = asteroid.GetComponent<Asteroid>();
                asteroid.SetActive(true);
                asteroid.transform.position = asteroidParent.transform.position;
                asteroid.transform.localScale = asteroidParent.transform.localScale * 0.7f;
                asteroidComp.Speed *= asteroidsPoolData.SpeedIncrementInSubdivisions;
                asteroidComp.Direction = asteroidsPoolMovement.Random2DDirection();
                if (asteroid.transform.localScale.x < 1f && asteroid.transform.localScale.x > 0.5f) asteroidComp.Life = asteroidComp.BaseLife * 0.5f;
                else if (asteroid.transform.localScale.x < 0.5f) asteroidComp.Life = asteroidComp.BaseLife * 0.2f;
                else asteroidComp.Life = asteroidComp.BaseLife;
            }
        }

        //The starting viewport coordinates to be translated to world coordinates 
        private Vector3 RandomStartingPosInViewport()
        {
            Vector3 asteroidPosition = RandomStartingAsteroidPosition(new Vector2(0.5f, 0.5f), Random.Range(0.2f, 0.5f), 10);
            return cameraManager.MainCamera.ViewportToWorldPoint(new Vector3(asteroidPosition.x, asteroidPosition.y, playerInitialization.PlayerViewport.z));
        }

        Vector2 RandomStartingAsteroidPosition(Vector2 center, float radius, int subdivisions)
        {
            Vector2[] asteroidsPositions = new Vector2[subdivisions];
            for (int i = 0; i < subdivisions; i++)
            {
                float angle = (float)(i + 1) / (float)subdivisions * Mathf.PI * 2.0f;
                asteroidsPositions[i] = center + new Vector2(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius);
            }
            return asteroidsPositions[Random.Range(0, subdivisions - 1)];
        }

        public IEnumerator WaitRespawnAsteroids()
        {
            asteroidsPoolData.RestartingNewLevel = true;
            yield return new WaitForSeconds(3f);
            gameReset.RestartLevel();
        }
    }
}
