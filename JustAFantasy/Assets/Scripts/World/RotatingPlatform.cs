using UnityEngine;
using System.Collections;

public class RotatingPlatform : MonoBehaviour {

	// Raggio di rotazione, delta t, t iniziale
	public float radius, step,timepassed;

	//x e y del centro di rotazione
	public float xcenter,ycenter;

    public bool rotating = true;

	Transform tf=null;

	void Start() {
		tf = GetComponent<Transform> () as Transform;
	}

	// Update is called once per frame
	void Update () {

        if (rotating)
        {

            //aggiorno il tempo
            timepassed += step;

            //x=xcentro + Rcos(t+delta t)
            float xnew = xcenter + radius * Mathf.Cos(timepassed);

            //y=ycentro + Rsen(t+deltat)
            float ynew = ycenter + radius * Mathf.Sin(timepassed);
            tf.position = new Vector2(xnew, ynew);
        }
	}

    void RotateOn()
    {
        rotating = true;
    }

    void RotateOff()
    {
        rotating = false;
    }
}
