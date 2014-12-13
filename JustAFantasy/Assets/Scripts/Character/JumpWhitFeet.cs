using UnityEngine;
using System.Collections;

public class JumpWhitFeet : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
        if(!other.gameObject.tag.Equals("FriendFire") && !other.gameObject.tag.Equals("EnemyFire"))
		    (transform.parent.GetComponent<MovableWASD>() as MovableWASD).allowJump();
	}

    void OnTriggerExit2D(Collider2D other)
    {
        if (!other.gameObject.tag.Equals("FriendFire") && !other.gameObject.tag.Equals("EnemyFire"))
         (transform.parent.GetComponent<MovableWASD>() as MovableWASD).denyJump();
    }
}
