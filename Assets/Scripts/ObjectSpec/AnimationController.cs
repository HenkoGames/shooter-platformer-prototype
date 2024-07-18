using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    public MovementControler movementControler;
    public Rigidbody2D rg;
    public SpriteRenderer spriteRenderer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rg.velocity.x < 0 ) spriteRenderer.flipX = true;
        else spriteRenderer.flipX = false;

        animator.SetFloat("Speed", Mathf.Abs(rg.velocity.x));

        if (movementControler.canJump) animator.SetBool("onAir", false);
        else animator.SetBool("onAir", true);
    }
}
