using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public Gun gun;
    public Transform target;
    public int team;
    public bool canShoot = true;

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
        Shoot(target.position - transform.position,team);
    }
    public void Shoot(Vector2 direction)
    {
        Shoot(direction, team);
    }
    public void Shoot(Vector2 direction, int team)
    {
        if (canShoot)
        {
            Instantiate<GameObject>(gun.shell, transform.position, Quaternion.identity).GetComponent<Shell>().SetUp(gun, direction, team, gun.speed);
            StartCoroutine(coolDown());
        }
    }
    IEnumerator coolDown()
    {
        canShoot = false;
        yield return new WaitForSeconds(gun.reloadTime);
        canShoot = true;
    }
}
