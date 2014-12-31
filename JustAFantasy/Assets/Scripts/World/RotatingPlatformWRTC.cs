using UnityEngine;
using System.Collections;

public class RotatingPlatformWRTC : MonoBehaviour {

    public float speed = 0.5f; // u/s
    public float radius = 1.0f;
    public Vector2 center = new Vector2(0, 0);
    public bool clockwise = true;
    public float startingAngle = 270.0f;
    public bool rotating = true;

    private float rad;
	// Use this for initialization
	void Start () {
        startingAngle = startingAngle % 360;
        rad = (startingAngle / 180.0f) * Mathf.PI;
	}
	
	// Update is called once per frame
	void Update () {
		if (rotating){
	        if(!clockwise)
	            rad += speed * Time.deltaTime / radius;
	        else
	            rad -= speed * Time.deltaTime / radius;
	        rad = rad % (2 * Mathf.PI);
	        Vector2 pos = new Vector2(Mathf.Cos(rad) * radius, Mathf.Sin(rad) * radius);
	        transform.localPosition = center + pos;
		}
	}

	void RotateOn () {
		rotating=true;
	}

	void RotateOff () {
		rotating=false;
	}
}
