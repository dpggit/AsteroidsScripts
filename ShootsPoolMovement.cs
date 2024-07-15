using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class ShootPoolMovement : MonoBehaviour
    {
        public void MoveShoot()
        {
            foreach (ShootInteractions s in transform.GetComponentsInChildren<ShootInteractions>())
            {
                if (s.gameObject.activeInHierarchy)
                {
                    ShootData sd = s.GetComponent<ShootData>();
                    s.ActualDistance += sd.Speed * Time.deltaTime;
                    //If laser shoot reached the max distance disable it
                    if (s.ActualDistance < sd.MaxDistance) s.transform.position += s.Direction * sd.Speed * Time.deltaTime;
                    else
                    {
                        s.ActualDistance = 0;
                        s.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}
