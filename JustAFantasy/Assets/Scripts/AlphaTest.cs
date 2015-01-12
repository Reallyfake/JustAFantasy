using UnityEngine;
using System.Collections;

public class AlphaTest : MonoBehaviour {

	SpriteRenderer sp;
	Color c;
	public float speed;
	public bool fill=false;

	// Use this for initialization
	void Start () {
		sp= this.GetComponent<SpriteRenderer>() as SpriteRenderer;
		c=sp.material.color;
		c.a=0f;
		sp.material.color=c;
	}
	
	// Update is called once per frame
	void Update () {

		if (fill && sp.material.color.a <1f){
			c=sp.material.color;
			c.a+=speed*Time.deltaTime;
			sp.material.color=c;
		}
	
	}

	void Active(){
		fill=true;
	}

	void DeActive(){
		fill=true;
	}

	void MoveOn(){
		fill=true;
	}

	void RotateOn(){
		fill=true;
	}

	void Die(){
		fill=true;
	}
}
