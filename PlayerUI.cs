using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class PlayerUI : MonoBehaviour
    {
        public Transform LivesContainer;
        public GameObject CanvasPlayerImagePrefab;

        private PlayerData playerData;

        void Start()
        {
            playerData = GetComponent<PlayerData>();
            for (int i = 0; i < playerData.Lives; i++)
            {
                Instantiate(CanvasPlayerImagePrefab).transform.SetParent(LivesContainer.transform);
            }
        }
    }
}
