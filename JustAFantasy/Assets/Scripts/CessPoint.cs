using UnityEngine;
using System.Collections;

public class CessPoint : MonoBehaviour {


	public GameObject lc;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") {
			if (this.GetComponent<Animator>() != null){
				this.GetComponent<Animator>().SetTrigger("touched");
			}
			if (this.GetComponent<AudioSource>() != null){
				this.GetComponent<AudioSource>().Play ();
			}
			lc.SendMessage("CheckPoint",this.transform.position);
            (this.GetComponent<BoxCollider2D>() as BoxCollider2D).enabled = false;
		}
	}

}
