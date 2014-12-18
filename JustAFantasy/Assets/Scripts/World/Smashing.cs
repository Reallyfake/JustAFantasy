using UnityEngine;
using System.Collections;

public class Smashing : MonoBehaviour {

	Transform tf = null;

	public bool Smash = true;
	public float initialPos = 2f;
	public float speedDown = 4f;
	public float speedUp = 2f;
	public float nextUp, nextDown;
    public LayerMask WhatIsGround;

	private bool earthLevel = false;

	
	// Use this for initialization
	void Start () {
		tf = transform;
//		tf.position.y = initialPos;
	}
	
	// Update is called once per frame
    void Update()
    {
        //check su avriablie globale modificata da collisione con player

        if (Smash == true)
        {
            SmashingIt();
        }

        if (Physics2D.OverlapCircle(transform.position, .5f, WhatIsGround))
        {
            nextUp = Time.time + nextDown;
            earthLevel = true;
        }

        //		tf.position = new Vector2 (tf.position.x, initialPos);
    }

    void SmashOn()
    {
        Smash = true;
    }

    void SmashOff()
    {
        Smash = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Instantiate(explosion, transform.position, transform.rotation);
            //Destroy(other.gameObject);
            other.gameObject.SendMessage("Die", SendMessageOptions.DontRequireReceiver);
        }
        //	new Vector2 (tf.position.x, initialPos);
    }

    void SmashingIt()
    {
        if (!earthLevel)
        {
            tf.position = tf.position + Vector3.down * speedDown * Time.deltaTime;
        }
        else
        {
            if (Time.time > nextUp)
            {
                tf.position = tf.position + Vector3.up * speedUp * Time.deltaTime;
                if (tf.position.y > initialPos)
                {
                    earthLevel = false;
                }
            }
        }
    }

}
