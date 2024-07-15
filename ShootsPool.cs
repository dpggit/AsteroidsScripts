using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class ShootsPool : MonoBehaviour
    {
        private ShootsPoolInitialization shootsPoolInitialization;
        private ShootPoolMovement shootPoolMovement;

        private void Start()
        {
            shootPoolMovement = GetComponent<ShootPoolMovement>();
        }

        void OnEnable()
        {
            shootsPoolInitialization = GetComponent<ShootsPoolInitialization>();
            shootsPoolInitialization.StartPool();
        }

        private void Update()
        {
            shootPoolMovement.MoveShoot();
        }
    }
}
