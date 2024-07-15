﻿//Asteroids by Diego Pena Gayo 12/07/2024 All rights reserved

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Explosion : MonoBehaviour
    {
        [field: SerializeField]
        public float TimeToBeDisabled { get; private set; }
        [HideInInspector]
        public float TimeWhenDisabled;
        [HideInInspector]
        public bool HasExploded;
    }
}