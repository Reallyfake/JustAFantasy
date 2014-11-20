using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
	
	public Vector2 padding = new Vector2(0.05f, 0.05f);
	public GUITexture lifePoint;	
	public GUIText font;
	public Camera cam;
	private float lifeRatio;
	private float screenRatio;
	private Character character;
	private GUITexture[] lifePoints;
	private Rect r = new Rect ();

	// Use this for initialization
	void Start () {
		character = GetComponent<Character> () as Character;
		lifePoints = new GUITexture[character.lifePoints];

		lifeRatio = lifePoint.texture.width / lifePoint.texture.height;
		screenRatio = cam.pixelWidth / cam.pixelHeight;


		r.width = (cam.pixelWidth/screenRatio) * 0.05f;
		r.height = cam.pixelHeight * 0.05f * lifeRatio;
		r.x = -r.width/2;
		r.y = -r.height/2;

		for (int i=0; i< character.lifePoints; i++) {
						lifePoints [i] = Instantiate (lifePoint) as GUITexture;
						lifePoints[i].transform.position = new Vector2 (padding.x + (i*0.05f), 1f - padding.y);
						lifePoints[i].pixelInset = r;
				}
		Instantiate (font);


	}
	
	// Update is called once per frame
	void Update () {
		if (character.lifePoints < lifePoints.Length && lifePoints [character.lifePoints] != null) {
						int i = character.lifePoints;
						while (i<lifePoints.Length && lifePoints[i]!=null) {
								Destroy (lifePoints [i]);
								//lifePoints [i] = null;
								i++;
						}
				} else if (character.lifePoints - 1 >= 0 && lifePoints [character.lifePoints - 1] == null) {
			int i = character.lifePoints-1;
			while(i>=0 && lifePoints[i]==null){
				lifePoints [i] = Instantiate (lifePoint) as GUITexture;
				lifePoints[i].transform.position = new Vector2 (padding.x + (i*0.05f), 1f - padding.y);
				lifePoints[i].pixelInset = r;
				i--;
			}
				}
	}
}
