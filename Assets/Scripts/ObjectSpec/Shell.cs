using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Shell : MonoBehaviour
{
    public Collider2D col;
    public Rigidbody2D rg;
    public Gun gun;
    public int team;
    public int collisions = 0;

    public void SetUp(Gun gunVar, Vector2 direction, int teamVar, float speed)
    {
        col = GetComponent<Collider2D>();
        rg = GetComponent<Rigidbody2D>();
        gun = gunVar;
        rg.velocity = Vector2.zero + direction.normalized * speed;
        team = teamVar;
        if (rg.velocity.magnitude <= 0.5) Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //bug here!!!
        
        if(collision.TryGetComponent<HealthPoints>(out HealthPoints hp))
        {
            if(hp.team != team){
                hp.GetDamage(gun.damage);
                collisions++;
            }
        }
        else if(collision.TryGetComponent<Obstacle>(out Obstacle obstacle))
        {
            collisions++;
        }

        if(collisions >= gun.maxCollisions)Destroy(gameObject);

    }
}
