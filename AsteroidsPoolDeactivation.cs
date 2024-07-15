using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class AsteroidsPoolDeactivation : MonoBehaviour
    {
        private AsteroidsPoolData asteroidPoolData;

        private void Start()
        {
            asteroidPoolData = GetComponent<AsteroidsPoolData>();
        }

        public void DisableAsteroids()
        {
            foreach (GameObject g in asteroidPoolData.ObjectsInPool)
            {
                g.SetActive(false);
            }
        }
    }
}
