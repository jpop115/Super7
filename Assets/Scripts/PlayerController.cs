using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float jumpSpeed = 10f;    
    public float speed = 10f;

    private Gun gun;
    private Rigidbody2D rigidBody;
    private bool jumped = false;
    private bool doubleJumped = false;
    private Health health;
    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();
        gun = GameObject.FindObjectOfType<Gun>();
    }
	
	// Update is called once per frame
	void Update () {
        Move();        
        Clamp();
	}

    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && !jumped)
        {
            Jump();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && !doubleJumped && jumped)
        {
            DoubleJump();
        }
    }

    private void Fire()
    {
        gun.FireGun();
    }

    private void Jump()
    {
        jumped = true;
        rigidBody.velocity = new Vector3(0, jumpSpeed, 0);
    }

    private void DoubleJump()
    {
        doubleJumped = true;
        rigidBody.velocity = new Vector3(0, jumpSpeed, 0);
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        
        if (collision.gameObject.GetComponent<Floor>())
        {
            jumped = false;
            doubleJumped = false;            
        }
        if (collision.gameObject.GetComponent<Wall>())
        {
            jumped = false;
        }
        if (collision.gameObject.GetComponent<Enemy>())
        {
            health.TakeDamage(10);

            rigidBody.velocity = new Vector2(-5f, 3f);
        }
    }

    void WallStick()
    {
        //transform.position.y
    }

    void Clamp()
    {
        Vector3 clampZRot;
        
        clampZRot = transform.eulerAngles;
        clampZRot.z = Mathf.Clamp(transform.eulerAngles.z, 0f, 0f);
        transform.eulerAngles = clampZRot;        
    }
}
