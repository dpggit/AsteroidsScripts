using Asteroids;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class PlayerInteractions : MonoBehaviour
    {
        [SerializeField]
        private GameReset gameReset;
        [SerializeField]
        private ExplosionsPoolInitialization explosionsPoolInit;

        private PlayerData playerData;
        private PlayerForceField playerForcefield;
        private PlayerDeathManagement playerDeathManagement;

        public void Start()
        {
            playerData = GetComponent<PlayerData>();
            playerForcefield = GetComponent<PlayerForceField>();
            playerDeathManagement = GetComponent<PlayerDeathManagement>();
        }

        public void CheckCollisions(Collider other)
        {
            if (!playerData.PlayerInvulnerable && !playerForcefield.ForceField.activeInHierarchy)
            {
                if (other.GetComponent<Asteroid>() || other.GetComponent<Enemy>())
                {
                    playerDeathManagement.DestroyPlayer();
                }
            }
            else
            {
                if (other.GetComponent<Asteroid>())
                {
                    explosionsPoolInit.Spawn(other.transform.position);
                    other.GetComponent<Asteroid>().Life = 0;
                }
                else if (other.GetComponent<Enemy>())
                {
                    explosionsPoolInit.Spawn(other.transform.position);
                    other.gameObject.SetActive(false);
                }
            }
        }
    }
}
