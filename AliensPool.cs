//Asteroids by Diego Pena Gayo 12/07/2024 All rights reserved

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class AliensPool : MonoBehaviour
    {
        [SerializeField]
        private PlayerData playerData;
        [SerializeField]
        private PlayerInitialization playerInitialization;

        [SerializeField]
        private AsteroidsPoolData asteroidsPoolData;
        [SerializeField]
        private ShootsPoolData shootsPoolData;
        [SerializeField]
        private GameData gameData;
        [SerializeField]
        private GameObject poolPrefab;
        [SerializeField]
        private CameraManager cameraManager;

        private AliensPoolMovement aliensPoolMovement;
        private AliensPoolAttack aliensPoolAttack;
        private AliensPoolSpawn aliensPoolSpawn;

        private bool aliensAppeared;

        private void Start()
        {
            aliensPoolMovement = GetComponent<AliensPoolMovement>();
            aliensPoolAttack = GetComponent<AliensPoolAttack>();
            aliensPoolSpawn = GetComponent<AliensPoolSpawn>();
        }

        private void Update()
        {
            //Just get the active asteroids as GetComponentsInChildren gives just the ones active by default
            aliensAppeared = false;
            if (transform.GetComponentsInChildren<Alien>().Length > 0)
            {
                foreach (Alien s in transform.GetComponentsInChildren<Alien>())
                {
                    aliensAppeared = true;
                    aliensPoolMovement.MoveAlien(s);
                    aliensPoolAttack.AliensAttack(s);
                }
            }
            if(!aliensAppeared && !asteroidsPoolData.RestartingNewLevel)
            {
                aliensPoolSpawn.CheckIfSpawnAlien();
            }
        }
    }
}

