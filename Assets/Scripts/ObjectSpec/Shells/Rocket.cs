using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Shell
{
    public GameObject explosionOBJ;
    public ParticleSystem particles;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<HealthPoints>(out HealthPoints hp))
        {
            if (hp.team != team)
            {
                Explode();
                
            }
        }
        else if (collision.TryGetComponent<Obstacle>(out Obstacle obstacle) && !obstacle.canShootThrough)
        {
            collisions++;
        }

        if (collisions >= gun.maxCollisions) Explode();
    }
    public void Explode()
    {
        GameObject exp = Instantiate(explosionOBJ,transform.position, Quaternion.identity);
        exp.GetComponent<Explosion>().team = team;
        particles.Stop();
        particles.transform.parent = null;
        particles.transform.localScale = Vector3.one;
        Destroy(particles.gameObject, 2f);
        Destroy(gameObject);
        
    }
}
