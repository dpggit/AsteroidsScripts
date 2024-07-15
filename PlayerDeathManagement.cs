using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroids
{
    public class PlayerDeathManagement : MonoBehaviour
    {
        [SerializeField]
        private GameReset gameReset;
        [SerializeField]
        private GameSounds gameSounds;

        private PlayerData playerData;
        private PlayerRenderer playerRenderer;
        private PlayerForceField playerForceField;
        private PlayerUI playerUI;
        private PlayerInitialization playerInitialization;

        [field: SerializeField]
        public GameObject ExplosionPlayer { get; private set; }

        private Rigidbody rb;
        private BoxCollider boxCollider;

        void Start()
        {
            playerData = GetComponent<PlayerData>();
            playerRenderer = GetComponent<PlayerRenderer>();
            playerForceField = GetComponent<PlayerForceField>();
            playerUI = GetComponent<PlayerUI>();
            playerInitialization = GetComponent<PlayerInitialization>();
            rb = GetComponent<Rigidbody>();
            boxCollider = GetComponent<BoxCollider>();
        }

        public void DestroyPlayer()
        {
            if (playerData.PlayerInvulnerable || playerForceField.ForceField.activeInHierarchy) return;
            ExplosionPlayer.SetActive(true);
            foreach (ParticleSystem ps in ExplosionPlayer.GetComponentsInChildren<ParticleSystem>())
            {
                ps.Play();
            }
            gameSounds.ExplosionSound.Play();
            playerData.Lives--;
            Image[] livesImages = playerUI.LivesContainer.GetComponentsInChildren<Image>();
            for (int i = 0; i < livesImages.Length; i++)
            {
                if (i >= playerData.Lives) livesImages[i].enabled = false;
            }
            //If dead restart game and stats
            if (playerData.Lives == 0)
            {
                //We take player out of screen to make it dissapear
                transform.position = Vector3.one * 1000f;
                StartCoroutine(gameReset.WaitForRestartGame());
            }
            else
            {
                //Make dissapear player and reappear in 3 seconds with forcefield, and 2 seconds later forcefield dissapears
                StartCoroutine(DisablePlayer());
                StartCoroutine(playerForceField.Invulnerable());
            }
        }

        public void DisablePlayerInmediately()
        {
            playerData.PlayerDisabled = true;
            rb.velocity = Vector3.zero;
            playerRenderer.GetComponent<SpriteRenderer>().enabled = false;
            boxCollider.enabled = false;
            playerRenderer.Rocket.SetActive(false);
        }

        public void EnablePlayerInmediately()
        {
            ExplosionPlayer.SetActive(false);
            playerRenderer.GetComponent<SpriteRenderer>().enabled = true;
            boxCollider.enabled = true;
            transform.position = playerInitialization.StartingPos;
            transform.rotation = playerInitialization.StartingRot;
            playerRenderer.Rocket.SetActive(true);
            rb.velocity = Vector3.zero;
            playerData.PlayerDisabled = false;
            StartCoroutine(playerForceField.Invulnerable());
            playerForceField.ForceField.SetActive(true);
        }

        public IEnumerator DisablePlayer()
        {
            DisablePlayerInmediately();
            yield return new WaitForSeconds(3f);
            EnablePlayerInmediately();
        }
    }
}
