using Asteroids;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    //User interface in case i want to use a different type of input for movement, like input using buttons
    public class PlayerInput : MonoBehaviour, IPlayerInput
    {
        public Vector2 MovementDirection { get; private set; }
        public bool DetectActivity { get; private set; }
        public bool ForceFieldOn { get; private set; }
        private PlayerAttack playerAttack;

        void Start()
        {
            playerAttack = GetComponent<PlayerAttack>();  
        }

        public void ControlShooting()
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) playerAttack.Shoot();
        }

        public void GetMovemementDirection()
        {
            MovementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }

        public void CheckActivity()
        {
            DetectActivity = Input.anyKey;
        }

        public void CheckForceField()
        {
            ForceFieldOn = Input.GetAxis("Vertical") < 0;
        }
    }
}
