using UnityEngine;
using System.Collections;

public class JumpWhitFeet : MonoBehaviour {

    private bool isRunning = false;

	void OnTriggerEnter2D(Collider2D other){
        
        if(!other.gameObject.tag.Equals("FriendFire") && !other.gameObject.tag.Equals("EnemyFire"))
		    (transform.parent.GetComponent<MovableWASD>() as MovableWASD).allowJump();
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (!other.gameObject.tag.Equals("FriendFire") && !other.gameObject.tag.Equals("EnemyFire"))
            (transform.parent.GetComponent<MovableWASD>() as MovableWASD).allowJump();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!other.gameObject.tag.Equals("FriendFire") && !other.gameObject.tag.Equals("EnemyFire"))
            if (isRunning)
            {
                StopCoroutine(denyJump());
                isRunning = false;
            }
            StartCoroutine(denyJump());
    }

    IEnumerator denyJump()
    {
        isRunning = true;
        yield return new WaitForSeconds(.2f);
        (transform.parent.GetComponent<MovableWASD>() as MovableWASD).denyJump();
        isRunning = false;
    }
}
