using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//File that contain instruments and do a setup of the game
public class Core : MonoBehaviour
{
    private void Awake()
    {
        //Target FPS setup
        Application.targetFrameRate = 120;
    }
}
public static class ShootingTools
{
    /// <summary>
    /// This method checks every target in list for direct access through game scene.
    /// This instrument uses SingleTargetCast() method from same class for each object in targetsList
    /// </summary>
    /// <param name="startPoint">Start point of checking</param>
    /// <param name="targetsList">List of targets to check</param>
    /// <param name="layersThatTargets">LayerMask with objects that will be hit by chekcker(enemies, obstacles)</param>
    /// <returns>Game object that in direct access from startPoint</returns>
    public static GameObject CheckTargetsCast(Transform startPoint, List<GameObject> targetsList, LayerMask layersThatTargets)
    {
        foreach (GameObject check in targetsList)
        {
            if (SingleTargetCast(startPoint, check, layersThatTargets)) return check;
        }
        return null;
    }
    /// <summary>
    /// This method checks accessibility of target GameObject from transform through game scene
    /// </summary>
    /// <param name="transform">Start position</param>
    /// <param name="target">target game object</param>
    /// <param name="layersThatTargets">layers that will be checked(target and obstacle possible layers)</param>
    /// <returns>bool variable that describe access of target</returns>
    public static bool SingleTargetCast(Transform transform,GameObject target, LayerMask layersThatTargets)
    {
        Physics2D.queriesHitTriggers = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, target.transform.position - transform.position, 1000f, layersThatTargets);
        if (hit.collider.gameObject == target)
        {
            Debug.DrawLine(transform.position, hit.point, Color.green);
            return true;
        }
        else
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);
            return false;
        }
    }
}
