using UnityEngine;
using System.Collections;

public class OnMouseColor : MonoBehaviour {

    public Color color = Color.red;
    private Color prev, prevM;

    void Start()
    {
        prevM = renderer.material.color;
		if((GetComponent<TextMesh>() as TextMesh)!=null)
        	prev = (GetComponent<TextMesh>() as TextMesh).color;
		else
						prev = Color.white;
    }

	void OnMouseEnter() {
		renderer.material.color = color;
		if ((GetComponent<TextMesh> () as TextMesh) != null)
						(GetComponent<TextMesh> () as TextMesh).color = color;
        if ((GetComponent<SpriteRenderer>() as SpriteRenderer) != null)
        {
            (GetComponent<SpriteRenderer>() as SpriteRenderer).color = color;
        }
	}

	void OnMouseExit() {
		renderer.material.color = prevM;
		if((GetComponent<TextMesh>() as TextMesh)!=null)
        	(GetComponent<TextMesh>() as TextMesh).color = Color.white;
        if ((GetComponent<SpriteRenderer>() as SpriteRenderer) != null)
        {
            (GetComponent<SpriteRenderer>() as SpriteRenderer).color = Color.white;
        }
	}
}
