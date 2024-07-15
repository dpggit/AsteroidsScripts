using Asteroids;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class ShootInteractions : MonoBehaviour
    {
      //  [SerializeField]
       // private ExplosionsPoolInitialization explosionsPoolInit;
      //  [SerializeField]
      //  private GameData gameData;
     //   [SerializeField]
      //  private GameUI gameUI;
       // [SerializeField]
      //  private GameReset gameReset;

        //How much distance the projectil has moved
        [HideInInspector]
        public float ActualDistance;
        [HideInInspector]
        public Vector3 StartingPosition;
        [HideInInspector]
        public Vector3 Direction;
        [HideInInspector]
        public bool IsEnemyShoot;

        private ShootData shootData;

        private static ExplosionsPoolInitialization explosionsPoolInit;
        private static GameData gameData;
        private static GameUI gameUI;
        private static GameReset gameReset;
        private static PlayerDeathManagement playerDeathManagement;

        void Start()
        {
            shootData = GetComponent<ShootData>();
            FindObjsInScene();
        }

        public static void FindObjsInScene()
        {
            if (explosionsPoolInit == null) explosionsPoolInit = GameObject.FindAnyObjectByType<ExplosionsPoolInitialization>();
            if (gameData == null) gameData = GameObject.FindAnyObjectByType<GameData>();
            if (gameUI == null) gameUI = GameObject.FindAnyObjectByType<GameUI>();
            if (gameReset == null) gameReset = GameObject.FindAnyObjectByType<GameReset>();
            if (playerDeathManagement == null) playerDeathManagement = GameObject.FindAnyObjectByType<PlayerDeathManagement>();
        }

        public void ShootCollision(Collider other)
        {
            //If collided with asteroid increase score and create an explosion
            if (other.GetComponent<Asteroid>())
            {
                other.GetComponent<Asteroid>().Life -= shootData.Damage;
                explosionsPoolInit.Spawn(transform.position);
                if (other.GetComponent<Asteroid>().Life <= 0)
                {
                    gameData.Score += gameData.PointsPerAsteroidShoot;
                    gameUI.ScoreText.text = gameData.Score.ToString();
                }
                gameObject.SetActive(false);
            }
            else if (other.GetComponent<PlayerShip>() && IsEnemyShoot)
            {
                gameObject.SetActive(false);
                playerDeathManagement.DestroyPlayer();
            }
            else if (other.GetComponent<Enemy>())
            {
                //aliens ships are not affected by their own shots
                if (!IsEnemyShoot)
                {
                    other.gameObject.SetActive(false);
                    explosionsPoolInit.Spawn(transform.position);
                    gameData.Score += gameData.PointsPerAlienShoot;
                    gameUI.ScoreText.text = gameData.Score.ToString();
                }
            }
        }
    }
}
