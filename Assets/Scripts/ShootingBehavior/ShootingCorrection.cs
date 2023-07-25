using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingCorrection : MonoBehaviour
{
    public Collider2D targetArea;
    public GameObject currentTarget;
    public List<GameObject> targetsList = new List<GameObject>();
    public LayerMask layersThatTargets;

    void Awake()
    {
        try
        {
            targetArea = GetComponent<Collider2D>();
        }
        catch {
            Debug.Log("ShootingCorrection component must have collider 2D component in the same gameObject");
        }
    }


}
