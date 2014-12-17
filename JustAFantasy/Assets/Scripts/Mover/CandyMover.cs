using UnityEngine;
using System.Collections;

public class CandyMover : MonoBehaviour {

	// My transform
	Transform tf;

	// Initial angle, delta t, time needed to hit the target, current time
	public float angle, step, totalTime,timePassed,direction;

	//gravity
	public float g;

	// target position
	float xt,yt;

	//initial velocity
	public float velocity;

	//my position
	float xin,yin;

	//relative position of target wrt my coordinates
	float xrel,yrel;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> () as Transform;
		xin = tf.position.x;
		yin = tf.position.y;
		xrel= direction;
		yrel=0f;


		//solve parabolic equation for initial angle
		angle = Mathf.Atan ((yrel + 0.5f * g * totalTime * totalTime)/xrel);

		//solve atan problem of range
		if (xrel < 0) {
			angle += 3.14f;
				}

		//solve parabolic equation for initial velocity
		velocity = Mathf.Abs(xrel/(totalTime*Mathf.Cos(angle)));
	}
	
	// Update is called once per frame
	void Update () {

		//time = time + delta time
		timePassed += step;

		//update my position using parabolic equations

		//x=x0 + v0 cos(f) *t
		float xnew = xin + velocity * Mathf.Cos (angle)*timePassed;

		//y=y0 + v0 sin (f)*t - 1/2*g*t^2
		float ynew = yin + velocity * Mathf.Sin (angle)*timePassed - 0.5f * g * timePassed * timePassed;

		tf.position = new Vector2 (xnew , ynew );



	}
}
