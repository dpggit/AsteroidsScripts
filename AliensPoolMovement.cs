using Asteroids;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class AliensPoolMovement : MonoBehaviour
    {
        [SerializeField]
        private CameraManager cameraManager;

        private AliensPoolData aliensPoolData;

        private void Start()
        {
            aliensPoolData = GetComponent<AliensPoolData>();
        }

        public void MoveAlien(Alien s)
        {
            if (Mathf.PerlinNoise(0, Time.time + 100f) > aliensPoolData.ChanceToFailChangingDirection)
            {
                s.Direction = Random2DDirection();
            }
            s.transform.position += s.Direction * s.Speed * Time.deltaTime;
        }

        //Get a random direction for aliens in 2D
        public Vector3 Random2DDirection()
        {
            return cameraManager.MainCamera.transform.right * Random.Range(-1f, 1f) + cameraManager.MainCamera.transform.up * Random.Range(-1f, 1f);
        }
    }
}
