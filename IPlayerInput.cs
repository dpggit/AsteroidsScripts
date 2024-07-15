using System;
using UnityEngine;

namespace Asteroids
{
    interface IPlayerInput
    {
        Vector2 MovementDirection { get; }
        bool DetectActivity { get; }
        bool ForceFieldOn {  get; }

        void ControlShooting();
        void GetMovemementDirection();
        void CheckActivity();
        void CheckForceField();
    }
}
