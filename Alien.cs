//Asteroids by Diego Pena Gayo 12/07/2024 All rights reserved

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Alien : Enemy
    {
        [field: SerializeField]
        public float Speed { get; private set; }

        [HideInInspector]
        public Vector3 Direction;
    }
}
