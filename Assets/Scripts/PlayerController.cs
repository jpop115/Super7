using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float jumpSpeed = 10f;        
    public float gravity = 20f;
    public float moveSpeed = 10f;
    public Transform groundCheck;
    public LayerMask whatIsGround;

    private float groundRadius = .2f;
    private bool grounded = false;
    private bool facingRight = true;
    private Gun gun;    
    private bool jumped = false;
    private bool doubleJumped = false;
    private Health health;
    private Vector3 moveDirection = Vector3.zero;
    private Rigidbody2D rigidBody;
    private Animator anim;    
    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();
        gun = GameObject.FindObjectOfType<Gun>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        CheckGrounded();
        //anim.SetFloat("vSpeed", rigidBody.velocity.y);
        Move();        
    }
    

    private void Move()
    {
        float move = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(move));
        rigidBody.velocity = new Vector2(move * moveSpeed, rigidBody.velocity.y);

        if (move > 0 && !facingRight)
        {
            Flip();
        } else if (move < 0 && facingRight)
        {
            Flip();
        }               

        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded && !jumped)
        {
            Jump();            
            anim.SetBool("Ground", false);            
        } else if (Input.GetKeyDown(KeyCode.UpArrow) && !doubleJumped )
        {
            DoubleJump();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Dash();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public bool WhichDirectionFace()
    {
        return facingRight;
    }

    private void Fire()
    {
        if (facingRight) { gun.FireGun(10f); }
        if(!facingRight) { gun.FireGun(-10f); }
        anim.SetTrigger("isShooting");
    }

    private void Jump()
    {
        jumped = true;
        Debug.Log("Jumping");
        rigidBody.velocity = new Vector2(0f, jumpSpeed);        
    }
   
    private void DoubleJump()
    {
        doubleJumped = true;
        Debug.Log("Trying to double jump");
        rigidBody.velocity = new Vector2(0f, jumpSpeed-3f);
    }

    private void Dash()
    {
        Vector2 target = new Vector2(transform.position.x + 2f,0f);
        Vector2 startPosition;
        float t = 0;
        float timeToReachTarget = 5f;

        startPosition = transform.position;
        t += Time.deltaTime / timeToReachTarget;

        transform.position = Vector2.Lerp(startPosition, target, t);        
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {        
        if (collision.gameObject.GetComponent<Enemy>())
        {
            health.TakeDamage(10);

            //rigidBody.velocity = new Vector2(-5f, 3f);
        }
    }
        

    void WallStick()
    {
        //transform.position.y
    }

    private void CheckGrounded()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded);
        if (grounded)
        {
            jumped = false;
            doubleJumped = false;
        }
    }
}
