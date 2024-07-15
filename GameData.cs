using Asteroids;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroids
{
    public class GameData : MonoBehaviour
    {
        public int WaveLevel = 1;
        public int Score = 0;
        public int PointsPerAsteroidShoot = 100;
        public int PointsPerAlienShoot = 500;
    }
}
