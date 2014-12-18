using UnityEngine;
using System.Collections;

public class CessPoint : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") {
			this.GetComponent<Animator>().SetTrigger("touched");
			Debug.Log ("touchè");
		}
	}

}
