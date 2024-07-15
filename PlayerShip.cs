//Asteroids by Diego Pena Gayo 12/07/2024 All rights reserved
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroids
{
    public class PlayerShip : MonoBehaviour
    {
        [SerializeField]
        private GameReset gameReset;
        [SerializeField]
        private GameData gameData;
        [SerializeField]
        private CameraManager cameraManager;

        private IPlayerInput playerInput;
        private PlayerForceField playerForcefield;
        private PlayerMovement playerMovement;
        private PlayerRenderer playerRenderer;
        private PlayerInteractions playerInteractions;
        private PlayerData playerData;

        private void Start()
        {
            playerInput = GetComponent<IPlayerInput>();
            playerForcefield = GetComponent<PlayerForceField>();
            playerMovement = GetComponent<PlayerMovement>();
            playerRenderer = GetComponent<PlayerRenderer>();
            playerData = GetComponent<PlayerData>();
            playerInteractions = GetComponent<PlayerInteractions>();
        }

        private void Update()
        {
            if (playerData.Lives > 0 && !playerData.PlayerDisabled)
            {
                playerInput.GetMovemementDirection();
                playerInput.ControlShooting();
                playerInput.CheckForceField();
                playerRenderer.ActivateRocket(playerInput.MovementDirection.y > 0);
                playerMovement.MoveShip(playerInput.MovementDirection);
                playerForcefield.CheckForceField(playerInput.ForceFieldOn);
            }
            playerInput.CheckActivity();
            //if game is over detect if press any key to restart game
            gameReset.CheckGameRestart(playerInput.DetectActivity);
        }

        private void OnTriggerEnter(Collider other)
        {
            playerInteractions.CheckCollisions(other);
        }
    }
}


