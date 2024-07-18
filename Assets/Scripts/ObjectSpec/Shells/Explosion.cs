using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class Explosion : MonoBehaviour
{
    public int explosionDamage;
    public GameObject shells;
    public int shellsCount;
    private Collider2D col;
    [HideInInspector]
    public int team;
    // Start is called before the first frame update
    private void Awake()
    {
        col = GetComponent<Collider2D>();
    }
    void Start()
    {
        Destroy(gameObject, 2f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<HealthPoints>(out HealthPoints hp))
        {
            if (hp.team != team) 
            {
                hp.GetDamage(explosionDamage);
            }
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
