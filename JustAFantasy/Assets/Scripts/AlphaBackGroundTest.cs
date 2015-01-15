using UnityEngine;
using System.Collections;

public class AlphaBackGroundTest : MonoBehaviour {

	SpriteRenderer sp;
	Color c;
	public float v;
	// Use this for initialization
	void Start () {
		sp= this.GetComponent<SpriteRenderer>() as SpriteRenderer;
		c=sp.material.color;
		c.a=v;
		sp.material.color=c;
	}
	

}
