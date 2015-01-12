using UnityEngine;
using System.Collections;

public class HidePlatform : MonoBehaviour {

	public int ShowTime = 2;
	public int HideTime = 8;
	
	private bool visible = true;
	
	// Update is called once per frame
	void Update () {
		if (Time.time % (ShowTime + HideTime) <= ShowTime) {
			if(!visible){
						visible = true;
						SetActiveDavide (gameObject, visible);
				gameObject.SetActive (true);
			}

				} else {
			if(visible){
						visible = false;
						SetActiveDavide(gameObject,visible);
						gameObject.SetActive(true);
			}
				}
	}

	public static void SetActiveDavide(GameObject oggetto, bool active){
		oggetto.SetActive(active);
		foreach(Transform childTransform in oggetto.transform)
		{
			SetActiveDavide(childTransform.gameObject, active);
		}
	}
}
