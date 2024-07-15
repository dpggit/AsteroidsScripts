using Asteroids;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionsPoolDeactivate : MonoBehaviour
{
    public void CheckIfDisableExplosions(Explosion s)
    {
        if (s.HasExploded)
        {
            if (Time.time > s.TimeWhenDisabled + s.TimeToBeDisabled)
            {
                s.HasExploded = false;
                s.gameObject.SetActive(false);
            }
        }
    }
}
