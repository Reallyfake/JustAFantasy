using UnityEngine;
using System.Collections;

public class Activable : MonoBehaviour {

	//non può funzionare, vedremo se è sistemabile
	void Active(){
		if ((GetComponent<SpriteRenderer>() as SpriteRenderer) != null)
			(GetComponent<SpriteRenderer>() as SpriteRenderer).enabled = true;
		if ((GetComponent<CircleCollider2D>() as CircleCollider2D) != null)
			(GetComponent<CircleCollider2D>() as CircleCollider2D).enabled = true;
		if ((GetComponent<BoxCollider2D>() as BoxCollider2D) != null)
			(GetComponent<BoxCollider2D>() as BoxCollider2D).enabled = true;
		if ((GetComponent<PolygonCollider2D>() as PolygonCollider2D) != null)
			(GetComponent<PolygonCollider2D>() as PolygonCollider2D).enabled = true;
		if ((GetComponent<EdgeCollider2D>() as EdgeCollider2D) != null)
			(GetComponent<EdgeCollider2D>() as EdgeCollider2D).enabled = true;
	}

	void DeActive(){
		if ((GetComponent<SpriteRenderer>() as SpriteRenderer) != null)
			(GetComponent<SpriteRenderer>() as SpriteRenderer).enabled = false;
		if ((GetComponent<CircleCollider2D>() as CircleCollider2D) != null)
			(GetComponent<CircleCollider2D>() as CircleCollider2D).enabled = false;
		if ((GetComponent<BoxCollider2D>() as BoxCollider2D) != null)
			(GetComponent<BoxCollider2D>() as BoxCollider2D).enabled = false;
		if ((GetComponent<PolygonCollider2D>() as PolygonCollider2D) != null)
			(GetComponent<PolygonCollider2D>() as PolygonCollider2D).enabled = false;
		if ((GetComponent<EdgeCollider2D>() as EdgeCollider2D) != null)
			(GetComponent<EdgeCollider2D>() as EdgeCollider2D).enabled = false;
	}

	void Die(){
		Destroy (this.gameObject);
	}
}
