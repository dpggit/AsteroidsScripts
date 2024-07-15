//Asteroids by Diego Pena Gayo 12/07/2024 All rights reserved

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Asteroid : MonoBehaviour
    {
        public float Life;
        public float Speed;
        public float RotationSpeed;

        [HideInInspector]
        public Vector3 Direction;

        public float BaseSpeed { get; private set; }
        public float BaseLife { get; private set; }

        private void Awake()
        {
            BaseSpeed = Speed;
            BaseLife = Life;
        }
    }
}
