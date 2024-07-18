using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Gun")]
public class Gun : ScriptableObject
{
    public float damage;
    public float reloadTime;
    public float accuracy;
    public float distance;
    public float speed;
    public int maxCollisions;

    
    public GameObject shell;
    
}
