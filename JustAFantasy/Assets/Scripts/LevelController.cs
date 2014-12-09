using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	private GameObject WeaponWheel;
	private bool is_running = false;
	// Use this for initialization
	void Start () {
		WeaponWheel = transform.GetChild (0).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
						Time.timeScale = 0;
						transform.GetChild (1).gameObject.SetActive (true);
				}
		if (Input.GetKeyDown (KeyCode.W)) {
			if(is_running)
				StopCoroutine("DragWWTo");
			StartCoroutine("DragWWTo", 0f);
				}
		if (Input.GetKeyUp (KeyCode.W)) {
			if(is_running)
				StopCoroutine("DragWWTo");
			StartCoroutine("DragWWTo",1f);
		}
	}

	IEnumerator DragWWTo(float newPos) {
		is_running = true;
		float step = (newPos - WeaponWheel.transform.position.y) / 20;
		for (int f = 0; f < 20; f++) {
			WeaponWheel.transform.position = new Vector2(0, WeaponWheel.transform.position.y + step);
			yield return new WaitForSeconds(.005f);
		}
		WeaponWheel.transform.position = new Vector2 (0, newPos);
		is_running = false;
	}
}
