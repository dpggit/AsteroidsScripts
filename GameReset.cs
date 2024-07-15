using Asteroids;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

namespace Asteroids
{
    public class GameReset : MonoBehaviour
    {
        [SerializeField]
        private PlayerData playerData;
        [SerializeField]
        private GameSounds gameSounds;
        [SerializeField]
        private GameData gameData;
        [SerializeField] 
        private PlayerUI playerUI;
        [SerializeField]
        private GameUI gameUI;
        [SerializeField]
        private AsteroidsPoolInitialization asteroidsPoolInit;
        [SerializeField]
        private AsteroidsPoolData asteroidsPoolData;
        [SerializeField]
        private AsteroidsPoolDeactivation asteroidsPoolDeactivation;
        [SerializeField]
        private ExplosionsPoolInitialization explosionsPoolInit;
        [SerializeField]
        private AliensPoolInitialization aliensPoolInit;
        [SerializeField]
        private PlayerForceField playerForcefield;
        [SerializeField]
        private PlayerInitialization playerInitialization;
        [SerializeField]
        private PlayerForceField playerForceField;
        [SerializeField]
        private PlayerRenderer playerRenderer;
        [SerializeField]
        private PlayerDeathManagement playerDeathManagement;

        [field: SerializeField]
        public GameObject GameOver { get; private set; }
        [field: SerializeField]
        public GameObject RestartText { get; private set; }

        private void Awake()
        {
            StartCoroutine(DisableWaveText());
        }

        public void CheckGameRestart(bool pressedAnyKey)
        {
            if (pressedAnyKey && GameOver.activeInHierarchy)
            {
                if (RestartText.activeInHierarchy)
                {
                    RestartText.SetActive(false);
                    RestartGame();
                    playerDeathManagement.EnablePlayerInmediately();
                }
            }
        }

        //GameOver, restart game
        public void RestartGame()
        {
            gameData.WaveLevel = 1;
            asteroidsPoolData.SpawnedNumber = asteroidsPoolData.OriginalSpawnNumber;
            GameOver.SetActive(false);
            playerDeathManagement.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameData.Score = 0;
            gameUI.ScoreText.text = gameData.Score.ToString();
            asteroidsPoolData.SpawnedNumber = asteroidsPoolData.OriginalSpawnNumber;
            asteroidsPoolInit.ReinitializePool();
            aliensPoolInit.ReinitializePool();
            transform.position = playerInitialization.StartingPos;
            transform.rotation = playerInitialization.StartingRot;
            playerData.Lives = playerInitialization.StartingLives;
            Image[] livesImages = playerUI.LivesContainer.GetComponentsInChildren<Image>(true);
            for (int i = 0; i < livesImages.Length; i++)
            {
                livesImages[i].enabled = true;
            }
        }

        public IEnumerator WaitForRestartGame()
        {
            GameOver.SetActive(true);
            playerDeathManagement.DisablePlayerInmediately();
            yield return new WaitForSeconds(2f);
            RestartText.SetActive(true);
        }


        //Start a new wave 
        public void RestartLevel()
        {
            playerDeathManagement.GetComponent<Rigidbody>().velocity = Vector3.zero;
            //Increase wave level and show new wave level text for three seconds
            gameData.WaveLevel++;
            gameUI.WaveLevelText.transform.parent.gameObject.SetActive(true);
            gameUI.WaveLevelText.text = gameData.WaveLevel.ToString();
            StartCoroutine(playerDeathManagement.DisablePlayer());
            StartCoroutine(playerForceField.Invulnerable());

            StartCoroutine(DelayRestartLevel());
        }

        IEnumerator DelayRestartLevel()
        {
            aliensPoolInit.ReinitializePool();
            yield return new WaitForSeconds(3f);
            gameUI.WaveLevelText.transform.parent.gameObject.SetActive(false);
            playerRenderer.GetComponent<SpriteRenderer>().enabled = true;
            //Raise the number of asteroids every time there is a new wave
            asteroidsPoolData.SpawnedNumber++;
            asteroidsPoolDeactivation.DisableAsteroids();
            asteroidsPoolInit.ReinitializePool();
            explosionsPoolInit.ReinitializePool();
            transform.position = playerInitialization.StartingPos;
            transform.rotation = playerInitialization.StartingRot;
            playerDeathManagement.GetComponent<Rigidbody>().velocity = Vector3.zero;
            asteroidsPoolData.RestartingNewLevel = false;
        }

        IEnumerator DisableWaveText()
        {
            yield return new WaitForSeconds(3f);
            gameUI.WaveLevelText.transform.parent.gameObject.SetActive(false);
        }
    }
}
