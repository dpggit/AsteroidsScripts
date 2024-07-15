using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    public class PlayerForceField : MonoBehaviour
    {
        [field: SerializeField]
        public GameObject ForceField { get; private set; }

       // public bool IsForceFieldOn { get; private set; }

        private PlayerData playerData;
        private float lastTimeForcefieldUsed;
        private float BaseForceFieldPower;

        private void Awake()
        {
            playerData = GetComponent<PlayerData>();
            BaseForceFieldPower = playerData.ForceFieldPower;
        }

        private void Start()
        {
            StartCoroutine(Invulnerable());
        }

        public void CheckForceField(bool forceFieldOn)
        {
            if(forceFieldOn)
            {
                if (playerData.ForceFieldPower > 0 && !playerData.PlayerInvulnerable)
                {
                    lastTimeForcefieldUsed = Time.time;
                    playerData.ForceFieldPower -= Time.deltaTime;
                }
                ForceField.SetActive(playerData.ForceFieldPower > 0);
            }
            else if (!playerData.PlayerInvulnerable)
            {
                //If passed the time defined in ForceFieldDownTime since forcefieldpower became 0 start increasing forcefieldpower
                if (Time.time > lastTimeForcefieldUsed + playerData.ForceFieldDownTime)
                {
                    ForceField.SetActive(false);
                    playerData.ForceFieldPower += Time.deltaTime;
                    playerData.ForceFieldPower = Mathf.Min(BaseForceFieldPower, playerData.ForceFieldPower);
                }
                else ForceField.SetActive(false);
            }
        }

        public IEnumerator Invulnerable()
        {
            playerData.PlayerInvulnerable = true;
            yield return new WaitForSeconds(5f);
            playerData.PlayerInvulnerable = false;
            //ForceField.SetActive(false);
        }

        /*
        private void CheckForceField(float verticalAxis)
        {
            if (playerData.Lives > 0 && !playerData.PlayerDisabled)
            {
                if (verticalAxis < 0)
                {
                    IsForceFieldOn = true;
                }
                else
                {
                    IsForceFieldOn = false;
                }
            }
        }
        */
    }
}
