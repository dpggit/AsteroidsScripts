using Asteroids;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroids
{
    public class PlayerData : MonoBehaviour
    {
        #region forcefield
        //The higher this value the longer will last the forcefield
        public float ForceFieldPower = 5f;
        //How long time forcefield down after being depleted
        [field:SerializeField]
        public float ForceFieldDownTime { get; private set; } = 5f;
        #endregion

        #region movement
        [field: SerializeField]
        public float Speed { get; private set; } = 5f;
        //Speed when moving in oposite direction from the actual direction
        [field: SerializeField]
        public float SpeedTurn { get; private set; } = 20f;
        [field: SerializeField]
        public float RotSpeed { get; private set; } = 15f;
        #endregion

        #region attack
        [field: SerializeField]
        public float ShootMaxDistance { get; private set; } = 25f;
        [field: SerializeField]
        public float ShootSpeed { get; private set; } = 30f;
        [field: SerializeField]
        public int ShootDamage { get; private set; } = 50;
        #endregion

        public int Lives = 5;
        [HideInInspector]
        public bool PlayerInvulnerable;
        [HideInInspector]
        public bool PlayerDisabled;
        [field: SerializeField]
        public float PlayerDistanceFromCamera { get; private set; } = 30f;
    }
}
