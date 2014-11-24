using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	//Global informations
	public Vector2 padding = new Vector2(0.05f, 0.05f);

	private Rect r = new Rect ();
	private float screenRatio;
	private CharacterStats character;

	//Weapons
	public Texture2D baseWeapon;
	public Font font;

	//Life
	public Texture2D lifePointFull;
	public Texture2D lifePointEmpty;
	
	private float lifeRatio;
	private int lifeShown;
	private GameObject[] lifePoints;

	//Energy
	public GUIStyle progress_empty;
	public GUIStyle progress_full;
	public Texture2D emptyText;
	public Texture2D fullText;
	private Vector2 size = new Vector2(150,30);

	// Use this for initialization
	void Start () {
		character = GetComponent<CharacterStats> () as CharacterStats;
		lifePoints = new GameObject[character.LifePoints];


		lifeRatio = lifePointFull.width / lifePointFull.height;
		screenRatio = Screen.width/Screen.height;


		r.width = (Screen.width/screenRatio) * 0.05f;
		r.height = Screen.height * 0.05f * lifeRatio;
		r.x = -r.width/2;
		r.y = -r.height/2;

		for (int i=0; i< character.LifePoints; i++) {
			lifePoints [i] = new GameObject ();
			lifePoints[i].AddComponent<GUITexture>();
			lifePoints[i].guiTexture.texture = lifePointFull;
			lifePoints[i].guiTexture.pixelInset = r;
			lifePoints[i].transform.position = new Vector2 (padding.x + (i*0.05f), 1f - padding.y);
			lifePoints[i].transform.localScale = new Vector3(0,0,0);
				}

		lifeShown = character.LifePoints;

		GameObject myText = new GameObject ();
		myText.transform.position = new Vector2 (1f-2*padding.x, 1f-padding.y);
		myText.AddComponent<GUIText> ();
		myText.guiText.font = font;
		myText.guiText.text = Screen.height.ToString() + "/" + Screen.width.ToString();

	}

	void OnGUI()
	{
		GUI.BeginGroup (new Rect (Screen.width*padding.x - 10,Screen.height*padding.y + r.height,size.x,size.y));
		
		// Draw the background image
		GUI.Box (new Rect (0,0,size.x,size.y), emptyText, progress_empty);
		
		// Create a second Group which will be clipped
		// We want to clip the image and not scale it, which is why we need the second Group
		GUI.BeginGroup (new Rect (0,0,character.Energy * size.x, size.y));
		
		// Draw the foreground image
		GUI.Box (new Rect (0,0,size.x,size.y), fullText, progress_full);
		
		// End both Groups
		GUI.EndGroup ();
		
		GUI.EndGroup ();
		}
	
	// Update is called once per frame
	void Update () {

		if (character.LifePoints < lifeShown) {
			for(int i=character.LifePoints; i<lifeShown; i++){
				lifePoints[i].guiTexture.texture = lifePointEmpty;
			}
			lifeShown = character.LifePoints;
				} else if (character.LifePoints > lifeShown) {
			for(int i=lifeShown; i<character.LifePoints; i++){
				lifePoints[i].guiTexture.texture = lifePointFull;
			}
				}
				
	}
}
