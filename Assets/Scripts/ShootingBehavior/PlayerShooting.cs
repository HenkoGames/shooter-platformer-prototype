using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Joystick Joystick;
    private ShootController ShootController;
    [Space]
    public bool correctionActive;
    public ShootingCorrection correction;
    void Awake()
    {
        try
        {
            ShootController = GetComponent<ShootController>();
        }
        catch 
        {
            Debug.LogError("PlayerShooting component must have ShootController component in the same GameObject");
        }
        if(correctionActive)
        {

        }
    }
    void FixedUpdate()
    {
        if (Joystick.Direction.normalized.magnitude > 0.5f)
        {
            ShootController.Shoot();
        }
    }
}
