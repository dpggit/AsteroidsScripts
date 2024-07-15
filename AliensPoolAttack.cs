using Asteroids;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class AliensPoolAttack : MonoBehaviour
    {
        [SerializeField]
        private PlayerInitialization playerInitialization;

        private AliensPoolData aliensPoolData;
        [SerializeField]
        private ShootsPoolData shootsPoolData;

        private float lastTimeShooted;

        void Start()
        {
            aliensPoolData = GetComponent<AliensPoolData>();
        }

        public void AliensAttack(Alien s)
        {
            if (Time.time > lastTimeShooted + aliensPoolData.ShootingFrequency)
            {
                if (Mathf.PerlinNoise(Time.time, 0) > aliensPoolData.ChanceToFailTargetPlayer)
                {
                    Vector3 dir = (playerInitialization.transform.position - s.transform.position).normalized;
                    Shoot(s.transform.position + dir * 5f, dir);
                }
                else
                {
                    Vector2 randomTarget = Random.insideUnitCircle;
                    Vector3 dir = (playerInitialization.transform.position + new Vector3(randomTarget.x, 0, randomTarget.y) * 10f - s.transform.position).normalized;
                    Shoot(s.transform.position + dir * 5f, dir);
                }
            }
        }

        private void Shoot(Vector3 startPos, Vector3 direction)
        {
            lastTimeShooted = Time.time;
            GameObject shoot = shootsPoolData.GetAvailableObjectInPool();
            if (shoot != null)
            {
                ShootInteractions shootComp = shoot.GetComponent<ShootInteractions>();

                ShootData sd = shoot.GetComponent<ShootData>();
                shoot.transform.position = startPos;
                shoot.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                sd.Damage = 0;
                sd.MaxDistance = aliensPoolData.ShootMaxDistance;
                sd.Speed = aliensPoolData.ShootSpeed;
                shootComp.IsEnemyShoot = true;
                shootComp.Direction = direction;
                shootComp.StartingPosition = shoot.transform.position;
                shoot.SetActive(true);
            }
        }
    }
}
