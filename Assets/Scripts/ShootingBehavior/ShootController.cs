using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public Gun gun;
    public Transform target;
    public int team;

    private void Awake()
    {
        try
        {
            team = GetComponent<HealthPoints>().team;
        }
        catch { 
            team = 0;
        }
    }
    public void Shoot()
    {
        gun.Shoot(target.position - transform.position,team);
    }
    public void Shoot(Vector2 direction)
    {
        gun.Shoot(direction, team);
    }
}
