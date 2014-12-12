using UnityEngine;
using System.Collections;

public class JumpWhitFeet : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){

		(transform.parent.GetComponent<MovableWASD>() as MovableWASD).allowJump();
	}
}
