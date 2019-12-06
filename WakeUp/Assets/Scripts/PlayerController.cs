using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public float jumpSpeed;
    private Animator anim;

    private bool isJumping;
    private bool isRunning;

    private float move;
    private Rigidbody2D rb;

    bool facingRight = true;
    Vector3 localScale;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
        
    }
    private void Update()
    {
        move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(move * playerSpeed, rb.velocity.y);


        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpSpeed));
            isJumping = true;
            
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerSpeed = 10f;
        
        }
        else
            playerSpeed = 5f;

        RunAnimations();

       

    }

    private void LateUpdate()
    {
        CheckWhereToFace();
    }

    void CheckWhereToFace()
    {
        if (move > 0)

            facingRight = true;

        else if (move < 0)

            facingRight = false;


        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    void RunAnimations()
    {
 
            anim.SetFloat("Movment", Mathf.Abs(move));
   
            anim.SetBool("isRunning", isRunning);
   
            anim.SetBool("isJumping", isJumping);
    }

}

