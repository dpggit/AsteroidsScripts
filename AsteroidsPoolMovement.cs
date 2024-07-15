using Asteroids;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class AsteroidsPoolMovement : MonoBehaviour
    {
        [SerializeField]
        private CameraManager cameraManager;

        public void MoveAsteroid(Asteroid s)
        {
            //Move and rotate all the asteriods
            s.transform.position += s.Direction * s.Speed * Time.deltaTime;
            s.transform.Rotate(0, 0, Time.deltaTime * s.RotationSpeed);
        }

        //Get a random direction for asteriods in 2D
        public Vector3 Random2DDirection()
        {
            return cameraManager.MainCamera.transform.right * Random.Range(-1f, 1f) + cameraManager.MainCamera.transform.up * Random.Range(-1f, 1f);
        }
    }
}
