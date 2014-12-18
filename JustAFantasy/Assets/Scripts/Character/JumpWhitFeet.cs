using UnityEngine;
using System.Collections;

public class JumpWhitFeet : MonoBehaviour {

    private bool isRunning = false;
    private bool onTheFloor = false;
    private bool floorProximity = false;
    private GameObject floor;
    private Vector3 oldFloorPos;
    float dX, dY;

    void Update()
    {
        if (onTheFloor && (floorProximity = Physics2D.OverlapCircle(transform.position, .5f, (transform.parent.gameObject.GetComponent<MovableWASD>() as MovableWASD).WhatIsGround)))
        {
            dX = floor.transform.position.x - oldFloorPos.x;
            dY = floor.transform.position.y - oldFloorPos.y;
            transform.parent.gameObject.transform.position += new Vector3(dX, dY, 0);
            oldFloorPos = floor.transform.position;
            dX = 0;
            dY = 0;
        }else
        {
            onTheFloor = false;
        }
    }

	void OnTriggerEnter2D(Collider2D other){

		if (!other.gameObject.tag.Equals("FriendFire") && !other.gameObject.tag.Equals("EnemyFire") && !other.gameObject.tag.Equals("Spike") && !other.gameObject.tag.Equals("Item"))
        {
            if (isRunning)
            {
                StopCoroutine(denyJump());
                isRunning = false;
            }
            (transform.parent.GetComponent<MovableWASD>() as MovableWASD).allowJump();

            if (other.gameObject.tag.Equals("Floor"))
            {
                if (onTheFloor && floor != null && floor != other.gameObject)
                {
                    dX = floor.transform.position.x - oldFloorPos.x;
                    dY = floor.transform.position.y - oldFloorPos.y;
                }
                else
                {
                    dX = 0;
                    dY = 0;
                }
                
                floor = other.gameObject;
                oldFloorPos = floor.transform.position;
                onTheFloor = true;
            }
        }
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (!other.gameObject.tag.Equals("FriendFire") && !other.gameObject.tag.Equals("EnemyFire") && !other.gameObject.tag.Equals("Spike"))
        {
            (transform.parent.GetComponent<MovableWASD>() as MovableWASD).allowJump();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!other.gameObject.tag.Equals("FriendFire") && !other.gameObject.tag.Equals("EnemyFire") && !other.gameObject.tag.Equals("Spike"))
        {
            if (isRunning)
            {
                StopCoroutine(denyJump());
                isRunning = false;
            }
            StartCoroutine(denyJump());
        }
    }

    IEnumerator denyJump()
    {
        isRunning = true;
        yield return new WaitForSeconds(.1f);
        (transform.parent.GetComponent<MovableWASD>() as MovableWASD).denyJump();
        isRunning = false;
    }
}
