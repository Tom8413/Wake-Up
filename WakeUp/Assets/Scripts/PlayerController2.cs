using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float runspeed;
    public float walkSpeed;

    Rigidbody2D myRB;
    Animator myAnim;

    bool facingRight;
    Vector3 localScale;

    private void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        localScale = transform.localScale;
        facingRight = true;
    }
    private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        myAnim.SetFloat("Speed", Mathf.Abs(move));

        float walking = Input.GetAxisRaw("Fire3");
        myAnim.SetFloat("isWalking", walking);

        if (walking >0)
        {
            myRB.velocity = new Vector3(move * walkSpeed, myRB.velocity.y, 0);
        } else
        {
            myRB.velocity = new Vector3(move * runspeed, myRB.velocity.y, 0);
        }
            

        if (move > 0)
        {
            facingRight = true;
            Flip();
        }

            

        else if (move < 0)
        {
            facingRight = false;
            Flip();
        }
 
    }

   void Flip()
    {
        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;
    }
}
