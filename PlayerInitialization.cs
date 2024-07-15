using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class PlayerInitialization : MonoBehaviour
    {
        public Vector3 StartingPos { get; private set; }
        public Quaternion StartingRot { get; private set; }
        public int StartingLives { get; private set; }
        public Vector3 PlayerViewport { get; private set; }

        [SerializeField]
        private CameraManager cameraManager;

        private PlayerData playerData;

        private void Start()
        {
            playerData = GetComponent<PlayerData>();    
            StartingPos = transform.position;
            StartingRot = transform.rotation;
            StartingLives = playerData.Lives;
            //Set player viewport to be used by asteroids to be in same plane
            PlayerViewport = cameraManager.MainCamera.WorldToViewportPoint(transform.position);
        }
    }
}
