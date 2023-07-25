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
    private float startGravity;

    public float horisontalAcceleration;
    public float vertcalAcceleration;
    public float maxFallSpeed = 10f;

    [Space]
    public bool canJump = false;
    public LayerMask canJumpFrom;
    public float timeForJump = 0.3f;
    private float jumpTimer;

    private Vector2 vectorBuffer;

    void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        startGravity = rg.gravityScale;
    }
    private void FixedUpdate()
    {
        if (-rg.velocity.y > maxFallSpeed)
        {
            vectorBuffer.x = rg.velocity.x;
            vectorBuffer.y = -maxFallSpeed;
            rg.velocity = vectorBuffer;
        }

        if(rg.velocity.y < 0f)
        {
            rg.gravityScale = startGravity*1.5f; 
        }
        else
        {
            rg.gravityScale = startGravity ;
        }
    }
    public void Update()
    {
         CheckJump();
    }

    public void MovePlayer(Vector2 vector)
    {
        vectorBuffer.x = vector.x * horisontalAcceleration;
        vectorBuffer.y = rg.velocity.y;

        if (vector.y > 0.8f && canJump)
        {
            vectorBuffer.y = vertcalAcceleration;
            canJump = false;
        }

        rg.velocity = vectorBuffer;
    }

    private static bool additionalJumpTime = false;
    public void CheckJump()
    {
        if(Physics2D.BoxCast(col.bounds.center, col.bounds.size,0f, Vector2.down, 0.1f, canJumpFrom))
        {
            canJump = true;
            jumpTimer = timeForJump;
        }
        else
        {
            jumpTimer -= Time.deltaTime;
            if(jumpTimer < 0)canJump = false;
        }

    }
}
