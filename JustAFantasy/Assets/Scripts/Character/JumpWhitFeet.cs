using UnityEngine;
using System.Collections;

public class JumpWhitFeet : MonoBehaviour {
	public int count = 0;
	void OnTriggerEnter2D(Collider2D other){
		count ++;
		(transform.parent.GetComponent<MovableWASD>() as MovableWASD).allowJump();
	}
}
