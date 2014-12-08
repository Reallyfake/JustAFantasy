using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
						Time.timeScale = 0;
						transform.GetChild (1).gameObject.SetActive (true);
				}
		if (Input.GetKeyDown (KeyCode.W)) {
			transform.GetChild(0).gameObject.transform.position = new Vector2(0,0);
				}
		if (Input.GetKeyUp (KeyCode.W)) {
			transform.GetChild(0).gameObject.transform.position = new Vector2(0,1);
		}
	}
}
