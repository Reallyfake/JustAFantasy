using UnityEngine;
using System.Collections;

public class FloorRandomizer : MonoBehaviour {

    public Texture2D[] Sprites = new Texture2D[8];

	// Use this for initialization
	void Start () {
        gameObject.renderer.material.mainTexture = Sprites[Random.Range(0, 4)];
        
	}
	
}
