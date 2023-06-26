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
            if (CheckTarget(currentTarget)) shootController.Shoot(currentTarget.transform.position - transform.position);
            else CheckTargets();
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
                CheckTargets();
            }
        }
    }
    public void CheckTargets()
    {
        foreach (GameObject check in targetsList)
        {
            if (CheckTarget(check))
            {
                currentTarget = check;
                break;
            }
        }
    }
    public bool CheckTarget(GameObject target)
    {
        Physics2D.queriesHitTriggers = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, target.transform.position - transform.position, 1000f, layersThatChecks);
        if (hit.collider.gameObject == target)
        {
            Debug.DrawLine(transform.position, hit.point,Color.green);
            return true;
        }
        else
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);
            return false;
        }
    }

}
