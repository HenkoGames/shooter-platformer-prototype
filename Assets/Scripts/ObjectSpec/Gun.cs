using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage;
    public float reloadTime;
    public float accuracy;
    public float distance;
    public float speed;
    public int maxCollisions;

    public bool canShoot = true;
    public GameObject shell;
    public void Shoot(Vector2 direction, int team)
    {
        if (canShoot )
        {
            Instantiate<GameObject>(shell, transform.position, Quaternion.identity).GetComponent<Shell>().SetUp(this, direction, team, speed);
            StartCoroutine(coolDown());
        }
    }
    IEnumerator coolDown()
    {
        canShoot = false;
        yield return new WaitForSeconds(reloadTime);
        canShoot = true;
    }
}
