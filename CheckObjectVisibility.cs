//Asteroids by Diego Pena Gayo 12/07/2024 All rights reserved
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace Asteroids
{
    public class CheckObjectVisibility : MonoBehaviour
    {
        private static CameraManager cameraManager;

        //In case you want to move the root parent of the object and not the object itself
        public bool MovefinalTransform = false;

        public static void FindObjsInScene()
        {
            if (cameraManager == null) cameraManager = GameObject.FindAnyObjectByType<CameraManager>();
        }

        private void Start()
        {
            FindObjsInScene();
        }

        private void OnBecameInvisible()
        {
            //Dont apply for alien  shoots
            if(GetComponent<ShootInteractions>())
            {
                if (GetComponent<ShootInteractions>().IsEnemyShoot) return;
            }
            Transform finalTransform = transform;
            if (MovefinalTransform) finalTransform = transform.root;
            if (cameraManager.MainCamera == null) return;
            //Translate the object position to 0 to 1 viewport coordinates and then see if the coordinates go beyond 0 or 1 and if that happens invert the value, from 1 to 0 and 0 to 1
            Vector3 viewportPosition = cameraManager.MainCamera.WorldToViewportPoint(finalTransform.position);
            float vpx = viewportPosition.x;
            float vpy = viewportPosition.y;
            if (viewportPosition.x >= 1f || viewportPosition.x <= 0)
            {
                if (vpx > 1) vpx = 0;
                if (vpx < 0) vpx = 1;
            }
            if (viewportPosition.y >= 1f || viewportPosition.y <= 0)
            {
                if (vpy > 1) vpy = 0;
                if (vpy < 0) vpy = 1;
            }
            //Translate the viewport coordinates to world coordinates and set the object to that position
            finalTransform.position = cameraManager.MainCamera.ViewportToWorldPoint(new Vector3(vpx, vpy, viewportPosition.z));
        }
    }
}
