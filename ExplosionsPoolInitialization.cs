using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class ExplosionsPoolInitialization : MonoBehaviour
    {
        [SerializeField]
        private GameObject poolPrefab;
        [SerializeField]
        private GameSounds gameSounds;

        private ExplosionsPoolData explosionsPoolData;

        void Start()
        {
        }

        void OnEnable()
        {
            explosionsPoolData = GetComponent<ExplosionsPoolData>();
            StartPool();
        }

        private void StartPool()
        {
            GameObject obj = null;
            for (int i = 0; i < explosionsPoolData.PoolNumber; i++)
            {
                obj = Instantiate(poolPrefab);
                obj.SetActive(false);
                explosionsPoolData.ObjectsInPool.Add(obj);
                obj.transform.SetParent(transform);
            }
        }

        public void Spawn(Vector3 position)
        {
            GameObject objExplosion = explosionsPoolData.GetAvailableObjectInPool();
            if(objExplosion!=null)
            {
                objExplosion.SetActive(true);
                objExplosion.transform.position = position;
                objExplosion.GetComponent<ParticleSystem>().Play();
                if (objExplosion.GetComponent<Explosion>())
                {
                    objExplosion.GetComponent<Explosion>().HasExploded = true;
                    objExplosion.GetComponent<Explosion>().TimeWhenDisabled = Time.time;
                }
                gameSounds.ExplosionSound.Play();
            }
        }

        public void ReinitializePool()
        {
            for (int i = 0; i < explosionsPoolData.ObjectsInPool.Count; i++)
            {
                GameObject explosion = explosionsPoolData.ObjectsInPool[i];
                explosion.SetActive(false);
            }
        }
    }
}
