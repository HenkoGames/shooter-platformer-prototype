using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MovementControler : MonoBehaviour
{
    //Component that used in objects that moving with some logic
    //This component help other scripts move the object and analyse the factors that make a consequenses in movement logic
    [HideInInspector]
    public Rigidbody2D rg;
    [HideInInspector]
    public float horisontalSpeed;
    [HideInInspector]
    public float vertcalSpeed;
    [HideInInspector]
    public Collider2D col;

    public float horisontalAcceleration;
    public float vertcalAcceleration;
    public float maxFallSpeed = 10f;

    [Space]
    public bool canJump = false;

    private Vector2 vectorBuffer;

    void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }
    private void FixedUpdate()
    {
        if (-rg.velocity.y > maxFallSpeed)
        {
            vectorBuffer.x = rg.velocity.x;
            vectorBuffer.y = -maxFallSpeed;
            rg.velocity = vectorBuffer;
        }

        //Just a fast ground check, it will be fixed soon:)
        if (rg.velocity.y == 0)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
         }
    }

    public void MovePlayer(Vector2 vector)
    {
        vectorBuffer.x = vector.x * horisontalAcceleration;
        vectorBuffer.y = rg.velocity.y;

        if (vector.y > 0.8f && canJump)
        {
            rg.AddForce(new Vector2(0f, vertcalAcceleration));
        }

        rg.velocity = vectorBuffer;
    }
}
