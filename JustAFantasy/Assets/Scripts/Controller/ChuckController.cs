using UnityEngine;
using System.Collections;

public class ChuckController : MonoBehaviour {

	SpriteRenderer sp;
	Color c;
	public float speedFill,speedDeFill;
	public bool fill=true;
	
	// Use this for initialization
	void Start () {
		sp= this.GetComponent<SpriteRenderer>() as SpriteRenderer;
		c=sp.material.color;
		c.a=0f;
		sp.material.color=c;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (fill){
			if(sp.material.color.a <1f){
				c=sp.material.color;
				c.a+=speedFill*Time.deltaTime;
				sp.material.color=c;
			} else {
				fill=false;
				(this.GetComponent<BoxCollider2D>() as BoxCollider2D).enabled =false;
			}
		} else {
			if(sp.material.color.a >0f){
				c=sp.material.color;
				c.a-=speedDeFill*Time.deltaTime;
				sp.material.color=c;
			} else {
				Destroy(gameObject);
			}
		}
		
	}
	

}
