//Asteroids by Diego Pena Gayo 12/07/2024 All rights reserved
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class AsteroidsPool : MonoBehaviour
    {
        [SerializeField]
        private CameraManager cameraManager;
        [SerializeField]
        private GameReset gameReset;
        [SerializeField]
        private PlayerInitialization playerInitialization;

        private AsteroidsPoolInitialization asteroidsPoolInit;
        private AsteroidsPoolData asteroidsPoolData;
        private AsteroidsPoolMovement asteroidsPoolMovement;

        private void Start()
        {
            asteroidsPoolInit = GetComponent<AsteroidsPoolInitialization>();
            asteroidsPoolData = GetComponent<AsteroidsPoolData>();
            asteroidsPoolMovement = GetComponent<AsteroidsPoolMovement>();
        }

        private void Update()
        {
            //Just get the active asteroids as GetComponentsInChildren gives just the ones active by default
            if (transform.GetComponentsInChildren<Asteroid>().Length>0)
            {
                foreach (Asteroid s in transform.GetComponentsInChildren<Asteroid>())
                {
                    asteroidsPoolMovement.MoveAsteroid(s);
                    //If the asteroid has collided disable it and spawn other two smaller and faster asteroids
                    if (s.Life<=0)
                    {
                        if (s.transform.localScale.x > 0.5f)
                        {
                            for (int i = 0; i < asteroidsPoolData.Subdivisions; i++)
                            {
                                asteroidsPoolInit.Spawn(s);
                            }
                        }
                        s.Speed = s.BaseSpeed;
                        s.transform.localScale = Vector3.one;
                        s.gameObject.SetActive(false);
                    }
                }
            }
            else if(asteroidsPoolData.ObjectsInPool.Count > 0 && !asteroidsPoolData.RestartingNewLevel) StartCoroutine(asteroidsPoolInit.WaitRespawnAsteroids());
        }
    }
}
