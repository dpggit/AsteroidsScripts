using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

namespace Asteroids
{
    public class PlayerRenderer : MonoBehaviour
    {
        [field: SerializeField]
        public GameObject Rocket { get; private set; }

        public void ActivateRocket(bool activate)
        {
            Rocket.SetActive(activate);
        }
    }
}
