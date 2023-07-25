using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticShooter : MonoBehaviour
{
    [HideInInspector]
    public ShootController shootController;
    public Collider2D actionRadius;

    public GameObject currentTarget;
    public List<GameObject> targetsList = new List<GameObject>();

    public LayerMask layersThatChecks;
    void Awake()
    {
        try
        {
            shootController = GetComponent<ShootController>();
        }
        catch
        {
            Debug.LogError("StaticShooting component must have ShootController component in the same GameObject");
        }
    }
    private void Update()
    {
        
        if(targetsList.Count > 0 )
        {
            shootController.target = currentTarget.transform;
            if (ShootingTools.SingleTargetCast(transform, currentTarget, layersThatChecks)) shootController.Shoot(currentTarget.transform.position - transform.position);
            else ShootingTools.CheckTargetsCast(transform, targetsList, layersThatChecks);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<HealthPoints>(out HealthPoints hp) && hp.team != shootController.team)
        {
        targetsList.Add(collision.gameObject);

        if(currentTarget == null ) currentTarget=collision.gameObject;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (targetsList.Contains(collision.gameObject))
        {
            targetsList.Remove(collision.gameObject);
            if (currentTarget == collision.gameObject)
            {
                ShootingTools.CheckTargetsCast(transform, targetsList, layersThatChecks);
            }
        }
    }
}
