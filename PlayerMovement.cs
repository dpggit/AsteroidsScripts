using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private CameraManager cameraManager;

        private PlayerData playerData;
        private Rigidbody rb;

        private void Start()
        {
            playerData = GetComponent<PlayerData>();
            rb = GetComponent<Rigidbody>();
            //Set position in front of camera
            transform.position = cameraManager.MainCamera.transform.position + cameraManager.MainCamera.transform.forward * playerData.PlayerDistanceFromCamera;
        }

        public void MoveShip(Vector2 movementDirection)
        {
            if (rb.velocity.sqrMagnitude > 0)
            {
                if (Vector3.Dot(transform.up, rb.velocity.normalized) < -0.6f)
                {
                    rb.AddForce(transform.up * Mathf.Max(0, movementDirection.y) * Time.deltaTime * playerData.Speed * playerData.SpeedTurn);
                }
                else rb.AddForce(transform.up * Mathf.Max(0, movementDirection.y) * Time.deltaTime * playerData.Speed);
            }
            else rb.AddForce(transform.up * Mathf.Max(0, movementDirection.y) * Time.deltaTime * playerData.Speed);
            transform.rotation *= Quaternion.Euler(0, 0, movementDirection.x * -playerData.RotSpeed * Time.deltaTime);
        }
    }
}

