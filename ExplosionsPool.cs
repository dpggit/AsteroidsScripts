//Asteroids by Diego Pena Gayo 12/07/2024 All rights reserved
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class ExplosionsPool : MonoBehaviour
    {
        private ExplosionsPoolDeactivate explosionsPoolDeactivate;

        void Start ()
        {
            explosionsPoolDeactivate = GetComponent<ExplosionsPoolDeactivate>();
        }

        void Update()
        {
            if (GetComponentsInChildren<Explosion>().Length > 0)
            {
                Explosion[] arrExplo = GetComponentsInChildren<Explosion>();
                for (int i = 0; i < arrExplo.Length; i++)
                {
                    explosionsPoolDeactivate.CheckIfDisableExplosions(arrExplo[i]);
                }
            }
        }
    }
}
