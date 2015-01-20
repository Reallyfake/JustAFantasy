using UnityEngine;
using System.Collections;

public class DestroyActivable : MonoBehaviour {

	public GameObject[] destructable;
	int i;
	bool killMe;
	
	// Update is called once per frame
	void Update () {

		killMe = true;
		for (i=0;i<destructable.Length;i++){
			if (destructable[i] != null){
				killMe = false;
			}
		}	
		if (killMe){
			Destroy(gameObject);
		}
	}
}
