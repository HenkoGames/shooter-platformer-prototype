using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;
    private MovementControler movementControler;
    void Start()
    {
        try
        {
            movementControler = GetComponent<MovementControler>();
        }
        catch {
            Debug.LogError("PlayerMovement script must have movement controller in the same gameObject");
        }
    }

    private void FixedUpdate()
    {
        movementControler.MovePlayer(joystick.Direction);
    }
}
