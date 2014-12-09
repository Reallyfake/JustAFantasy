using UnityEngine;
using System.Collections;

public class jfWwResizer : MonoBehaviour {

	private float Rez;
	private const int dWidth = 1280;
	private const int dHeight = 720;
	private const float oldRatio = (float)dWidth / dHeight;
	private int screenWidth = Screen.width;
	private int screenHeight = Screen.height;
	private float newRatio = (float)Screen.width / Screen.height;
	private bool resOnWidth;

	// Use this for initialization
	void Start () {
		if (((float)dWidth / screenWidth) * screenHeight <= dHeight) {
						Rez = (float)screenHeight / dHeight;
						resOnWidth = false;
				} else {
						Rez = (float)screenWidth / dWidth;
						resOnWidth = true;
				}

		Rect r = (transform.GetChild (0).gameObject.GetComponent<GUITexture>() as GUITexture).pixelInset;
		(transform.GetChild (0).gameObject.GetComponent<GUITexture>() as GUITexture).pixelInset = new Rect (r.x * Rez, r.y * Rez, r.width * Rez, r.height * Rez);
		int fs = (transform.GetChild (1).gameObject.GetComponent<GUIText>() as GUIText).fontSize;
		fs = (int)(fs * Rez);
		fs = (fs > 0 ? fs : 1);
		(transform.GetChild (1).gameObject.GetComponent<GUIText>() as GUIText).fontSize = fs;

		for (int i=2; i<10; i++) {
			r = (transform.GetChild (i).gameObject.GetComponent<GUITexture>() as GUITexture).pixelInset;
			(transform.GetChild (i).gameObject.GetComponent<GUITexture>() as GUITexture).pixelInset = new Rect (r.x * Rez, r.y * Rez, r.width * Rez, r.height * Rez);
			Vector3 p = transform.GetChild (i).gameObject.transform.position;
			if(!resOnWidth)
				transform.GetChild(i).gameObject.transform.position = new Vector3(.5f + (p.x - .5f)*oldRatio/newRatio, p.y , p.z);
				}
	}

}
