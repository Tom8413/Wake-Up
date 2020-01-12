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

    bool grounded = false;
    //Collider[] groundCollisions;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;


    private void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        localScale = transform.localScale;
        facingRight = true;
    }
    private void Update()
    {
         if( grounded && Input.GetAxis("Jump")>0)
         {
         grounded = false;
         myAnim.SetBool("grounded", grounded);
         myRB.AddForce(new Vector2(0, jumpHeight));
         }
    }
    private void FixedUpdate()
    {
        //W Collision [] będzie informacja czy sfera pod nogami (o promieniu 0.2f) styka sie z podłożem. Wpierw ustawia sferę w groundCheck.position
        // potem rysuje ją do rozmiarów 0.2f a następnie sprawdza czy ta kulka dotyka Layer grouded
       // if( grounded && Input.GetAxis("Jump")>0)
        //{
         //   grounded = false;
          //  myAnim.SetBool("grounded", grounded);
           // myRB.AddForce(new Vector3(0, jumpHeight, 0));
        //}

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        //if (groundCollisions.Length > 0)
          //  grounded = true;
        //else
        
        //    grounded = false;



        myAnim.SetBool("grounded", grounded);
        myAnim.SetFloat("verticalSpeed", myRB.velocity.y);
        
  
        float move = Input.GetAxis("Horizontal");
        myAnim.SetFloat("Speed", Mathf.Abs(move));

        float walking = Input.GetAxisRaw("Fire3");
        myAnim.SetFloat("isWalking", walking);

        if (walking >0 && grounded)
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
