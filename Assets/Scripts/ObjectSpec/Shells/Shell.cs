using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Shell : MonoBehaviour
{
    [HideInInspector]
    public Collider2D col;
    [HideInInspector]
    public Rigidbody2D rg;
    [HideInInspector]
    public Gun gun;
    [HideInInspector]
    public int team;
    public int collisions = 0;

    public void SetUp(Gun gunVar, Vector2 direction, int teamVar, float speed)
    {
        col = GetComponent<Collider2D>();
        rg = GetComponent<Rigidbody2D>();
        gun = gunVar;
        rg.velocity = Vector2.zero + GetRandomDirection(direction,gun.accuracy).normalized * speed;
        team = teamVar;
        if (rg.velocity.magnitude <= 0.5) Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
        if(collision.TryGetComponent<HealthPoints>(out HealthPoints hp))
        {
            if(hp.team != team){
                hp.GetDamage(gun.damage);
                collisions++;
            }
        }
        else if(collision.TryGetComponent<Obstacle>(out Obstacle obstacle) && !obstacle.canShootThrough)
        {
            collisions++;
        }

        if(collisions >= gun.maxCollisions)Destroy(gameObject);

    }
    public static Vector2 GetRandomDirection(Vector2 startDirection, float maxRandomRange)
    {
        float rnd =  UnityEngine.Random.Range(-maxRandomRange * math.PI/180, maxRandomRange * math.PI/180);
        Vector2 res = new Vector2(Mathf.Cos(rnd)*startDirection.x - Mathf.Sin(rnd) * startDirection.y, Mathf.Sin(rnd) * startDirection.x + Mathf.Cos(rnd) * startDirection.y);
        return res;
    }
}
