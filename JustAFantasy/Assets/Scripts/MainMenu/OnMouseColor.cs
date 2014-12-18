using UnityEngine;
using System.Collections;

public class OnMouseColor : MonoBehaviour {

    public Color color = Color.red;
    private Color prev, prevM;

    void Start()
    {
        prevM = renderer.material.color;
        prev = (GetComponent<TextMesh>() as TextMesh).color;
    }

	void OnMouseEnter() {
		renderer.material.color = color;
        (GetComponent<TextMesh>() as TextMesh).color = color;
	}

	void OnMouseExit() {
		renderer.material.color = prevM;
        (GetComponent<TextMesh>() as TextMesh).color = prev;
	}
}
