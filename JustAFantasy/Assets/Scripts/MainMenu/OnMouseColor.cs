using UnityEngine;
using System.Collections;

public class OnMouseColor : MonoBehaviour {

    public Color color = Color.red;
    private Color prev, prevM;
	WorldMapNumber wn;

    void Start()
    {
        prevM = renderer.material.color;
		if((GetComponent<TextMesh>() as TextMesh)!=null)
        	prev = (GetComponent<TextMesh>() as TextMesh).color;
		else
						prev = Color.white;
		wn = this.GetComponent<WorldMapNumber>() as WorldMapNumber;
    }

	void OnMouseEnter() {
		if ((wn != null && wn.unlocked) || (wn == null)){
			renderer.material.color = color;
			if ((GetComponent<TextMesh> () as TextMesh) != null)
							(GetComponent<TextMesh> () as TextMesh).color = color;
	        if ((GetComponent<SpriteRenderer>() as SpriteRenderer) != null)
	        {
	            (GetComponent<SpriteRenderer>() as SpriteRenderer).color = color;
	        }
		}
	}

	void OnMouseExit() {
		if ((wn != null && wn.unlocked) || (wn == null)){
			renderer.material.color = prevM;
			if((GetComponent<TextMesh>() as TextMesh)!=null)
	        	(GetComponent<TextMesh>() as TextMesh).color = Color.white;
	        if ((GetComponent<SpriteRenderer>() as SpriteRenderer) != null)
	        {
	            (GetComponent<SpriteRenderer>() as SpriteRenderer).color = Color.white;
	        }
		}
	}
}
