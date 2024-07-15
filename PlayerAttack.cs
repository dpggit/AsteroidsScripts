using Asteroids;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField]
        private ShootsPoolData shootsPoolData;
        [SerializeField]
        private Transform shootingPoint;

        private PlayerData playerData;
        private PlayerSounds playerSounds;

        private void Start()
        {
            playerData = GetComponent<PlayerData>();
            playerSounds = GetComponent<PlayerSounds>();
        }

        public void Shoot()
        {
            GameObject shoot = shootsPoolData.GetAvailableObjectInPool();
            if (shoot != null)
            {
                ShootInteractions shootComp = shoot.GetComponent<ShootInteractions>();
                ShootData sd = shoot.GetComponent<ShootData>();
                sd.Damage = playerData.ShootDamage;
                playerSounds.ShootSound.Play();
                shoot.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                sd.Speed = playerData.ShootSpeed;
                sd.MaxDistance = playerData.ShootMaxDistance;
                shoot.transform.position = shootingPoint.position;
                shoot.transform.rotation = shootingPoint.rotation;
                shootComp.StartingPosition = shoot.transform.position;
                shootComp.Direction = transform.up;
                shootComp.IsEnemyShoot = false;
                shoot.SetActive(true);
            }
        }
    }
}
