using UnityEngine;
using System.Collections;

public class MovableWASD : MonoBehaviour {

	public float maxSpeed = 8f;
	public float jumpHeight = 2.7f;
	private Rigidbody2D rb;
	private bool canJump = false;
    public bool grounded = false;
	public bool preGrounded = true;
    public LayerMask WhatIsGround;
    private GameObject feet;
    private jfWeapon weapon;
    private Animator anim;
    private bool canMove = true;
	private AudioSource[] audioPlayer; 


    public void allowJump()
    {
        canJump = true;
    }

    public void denyJump()
    {
        canJump = false;
    }

	// Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>() as Rigidbody2D;
        feet = transform.GetChild(0).gameObject;
        anim = this.GetComponent<Animator>() as Animator;
		audioPlayer = transform.GetChild(2).gameObject.GetComponents<AudioSource>() as AudioSource[];
    }

    bool isForward()
    {
        return Input.GetKey(KeyCode.RightArrow);
    }

    bool isBackward()
    {
        return Input.GetKey(KeyCode.LeftArrow);
    }

    bool isDown()
    {
        return Input.GetKey(KeyCode.DownArrow);
    }

    bool isJump()
    {
        return Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.Space);
    }

	// Update is called once per frame
    void Update()
    {
        if (transform.GetChild(1).gameObject != null)
            weapon = transform.GetChild(1).gameObject.GetComponent<jfWeapon>() as jfWeapon;

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            EdgeCollider2D stand = gameObject.GetComponent<EdgeCollider2D>() as EdgeCollider2D;
            stand.enabled = false;
            BoxCollider2D sit = gameObject.GetComponent<BoxCollider2D>() as BoxCollider2D;
            sit.enabled = true;
            anim.SetBool("isCrouching", true);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            EdgeCollider2D stand = gameObject.GetComponent<EdgeCollider2D>() as EdgeCollider2D;
            stand.enabled = true;
            BoxCollider2D sit = gameObject.GetComponent<BoxCollider2D>() as BoxCollider2D;
            sit.enabled = false;
            anim.SetBool("isCrouching", false);
        }

        if (isForward() && canMove && !isDown())
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            if (isBackward() && canMove && !isDown())
            {
                rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1f, transform.localScale.y, transform.localScale.z);
            }
            else
            {
                if (!isForward() && !isBackward() && canMove)
                {
                    rb.velocity = new Vector2(0, rb.velocity.y);
                }
            }
        }
        if (isJump() && canJump && !isDown())
        {
            rb.AddForce(transform.up * jumpHeight * 10, ForceMode2D.Impulse);
			audioPlayer[1].Play ();
            canJump = false;
            if (anim != null)
                anim.SetTrigger("Jumped");

            if (weapon != null)
                weapon.setTrigger("Jumped");
            
        }
        if (rb.velocity.x != 0)
        {

            if (anim != null)
                anim.SetBool("isRunning", true);
            if (weapon != null)
                weapon.setBool("isRunning", true);
        }
        else
        {
            if (anim != null)
                anim.SetBool("isRunning", false);
            if (weapon != null)
                weapon.setBool("isRunning", false);
        }
        grounded = Physics2D.OverlapCircle(feet.transform.position, .6f, WhatIsGround);
		if (!preGrounded && grounded){
			audioPlayer[2].Play ();
		}
        if (anim != null)
            anim.SetBool("inAir", !grounded);
        if (weapon != null)
            weapon.setBool("inAir", !grounded);
		preGrounded = grounded;
    }

    void SpikeHit(Vector3 spikePos)
    {
        rb.AddForce((transform.position - spikePos)*5, ForceMode2D.Impulse);
        StartCoroutine(knockBack(.2f));
    }

    IEnumerator knockBack(float s)
    {
        canMove = false;
        yield return new WaitForSeconds(s);
        canMove = true;
    }
}
