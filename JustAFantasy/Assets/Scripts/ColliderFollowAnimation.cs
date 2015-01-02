using UnityEngine;
using System.Collections;

public class ColliderFollowAnimation : MonoBehaviour {

	SpriteRenderer sp;
	BoxCollider2D bc;
	CircleCollider2D cc;

	// Use this for initialization
	void Start () {
		sp=this.GetComponent<SpriteRenderer>() as SpriteRenderer;
		bc=this.GetComponent<BoxCollider2D>() as BoxCollider2D;
		cc=this.GetComponent<CircleCollider2D>() as CircleCollider2D;
	}
	
	// Update is called once per frame
	void Update () {
		if (bc!=null){
			bc.size = sp.sprite.bounds.size;
			bc.center = sp.sprite.bounds.center;
		}
		if (cc!=null){
			cc.radius = Mathf.Min(sp.sprite.bounds.size.x,sp.sprite.bounds.size.y)/2f;
			cc.center = sp.sprite.bounds.center;
		}
	}
}
