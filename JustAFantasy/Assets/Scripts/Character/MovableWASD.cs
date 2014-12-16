using UnityEngine;
using System.Collections;

public class MovableWASD : MonoBehaviour {

	public float maxSpeed = 8f;
	public float jumpHeight = 2.7f;
	private Rigidbody2D rb;
	private bool canJump = false;
    public bool grounded = false;
    public LayerMask WhatIsGround;
    private GameObject feet;
    private Animator anim;
    private bool lookAhead = true;

    public void allowJump()
    {
        canJump = true;
    }

    public void denyJump()
    {
        canJump = false;
        if (anim != null)
            anim.SetBool("isJumping", false);
    }

	// Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>() as Rigidbody2D;
        feet = transform.GetChild(0).gameObject;
        anim = this.GetComponent<Animator>() as Animator;
    }

    bool isForward()
    {
        return Input.GetKey(KeyCode.RightArrow);
    }

    bool isBackward()
    {
        return Input.GetKey(KeyCode.LeftArrow);
    }

    bool isJump()
    {
        return Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.Space);
    }

	// Update is called once per frame
    void Update()
    {
        if (isForward())
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            if (isBackward())
            {
                rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1f, transform.localScale.y, transform.localScale.z);
            }
            else
            {
                if (!isForward() && !isBackward())
                {
                    rb.velocity = new Vector2(0, rb.velocity.y);
                }
            }
        }
        if (isJump() && canJump)
        {
            rb.AddForce(transform.up * jumpHeight * 10, ForceMode2D.Impulse);
            canJump = false;
            if (anim != null)
                anim.SetBool("isJumping", true);
        }
        if (rb.velocity.x != 0)
        {
            
            if (anim != null)
                anim.SetBool("isRunning", true);
        }
        else
        {
            if (anim != null)
                anim.SetBool("isRunning", false);
        }
        grounded = Physics2D.OverlapCircle(feet.transform.position, .5f, WhatIsGround);
        if (anim != null)
            anim.SetBool("inAir", !grounded);
    }
}
