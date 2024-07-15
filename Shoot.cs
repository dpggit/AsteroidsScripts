//Asteroids by Diego Pena Gayo 12/07/2024 All rights reserved

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Shoot : MonoBehaviour
    {
        private ShootInteractions shootInteractions;

        private void Start()
        {
            shootInteractions = GetComponent<ShootInteractions>();  
        }

        private void OnTriggerEnter(Collider other)
        {
            shootInteractions.ShootCollision(other);
        }
    }
}
