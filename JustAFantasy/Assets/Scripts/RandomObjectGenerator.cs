using UnityEngine;
using System.Collections;

public class RandomObjectGenerator : MonoBehaviour {


	public GameObject health;
	public GameObject banana;
	public GameObject caloric;
	public GameObject WTF;
	public GameObject fartMan;
	public GameObject gunTar;
	public GameObject catThrower;
	public GameObject Chat;
	GameObject o;
	float objectRandomChoice;
	float lastSpawn;
	public float spawnRatio = 20f; 

	void Start(){
		lastSpawn = Time.time + spawnRatio;
		objectRandomChoice = Random.Range(0f,7f);
		if (objectRandomChoice >= 0f && objectRandomChoice < 1f){
			o = Instantiate (banana,transform.position,transform.rotation) as GameObject;
		} else if (objectRandomChoice >= 1f && objectRandomChoice < 2f){
			o = Instantiate (caloric,transform.position,transform.rotation) as GameObject;
		} else if (objectRandomChoice >= 2f && objectRandomChoice < 3f){
			o = Instantiate (WTF,transform.position,transform.rotation) as GameObject;
		} else if (objectRandomChoice >= 3f && objectRandomChoice < 4f){
			o = Instantiate (fartMan,transform.position,transform.rotation) as GameObject;
		} else if (objectRandomChoice >= 4f && objectRandomChoice < 5f){
			o = Instantiate (gunTar,transform.position,transform.rotation) as GameObject;
		} else if (objectRandomChoice >= 5f && objectRandomChoice < 6f){
			o = Instantiate (catThrower,transform.position,transform.rotation) as GameObject;
		} else if (objectRandomChoice >= 6f && objectRandomChoice < 6.99f){
			o = Instantiate (health,transform.position,transform.rotation) as GameObject;
		} else if (objectRandomChoice >= 6.99f){
			o = Instantiate (Chat,transform.position,transform.rotation) as GameObject;
		}
		(o.GetComponent<Lootable>() as Lootable).respawn = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (o != null && (o.GetComponent<Lootable>() as Lootable).readActive==false && Time.time > lastSpawn){
			Destroy(o);
			lastSpawn = Time.time + spawnRatio;
			objectRandomChoice = Random.Range(0f,7f);
			if (objectRandomChoice >= 0f && objectRandomChoice < 1f){
				o = Instantiate (banana,transform.position,transform.rotation) as GameObject;
			} else if (objectRandomChoice >= 1f && objectRandomChoice < 2f){
				o = Instantiate (caloric,transform.position,transform.rotation) as GameObject;
			} else if (objectRandomChoice >= 2f && objectRandomChoice < 3f){
				o = Instantiate (WTF,transform.position,transform.rotation) as GameObject;
			} else if (objectRandomChoice >= 3f && objectRandomChoice < 4f){
				o = Instantiate (fartMan,transform.position,transform.rotation) as GameObject;
			} else if (objectRandomChoice >= 4f && objectRandomChoice < 5f){
				o = Instantiate (gunTar,transform.position,transform.rotation) as GameObject;
			} else if (objectRandomChoice >= 5f && objectRandomChoice < 6f){
				o = Instantiate (catThrower,transform.position,transform.rotation) as GameObject;
			} else if (objectRandomChoice >= 6f && objectRandomChoice < 6.99f){
				o = Instantiate (health,transform.position,transform.rotation) as GameObject;
			} else if (objectRandomChoice >= 6.99f){
				o = Instantiate (Chat,transform.position,transform.rotation) as GameObject;
			}
			(o.GetComponent<Lootable>() as Lootable).respawn = false;
		} else if (o != null && (o.GetComponent<Lootable>() as Lootable).readActive==true) {
			lastSpawn = Time.time + spawnRatio;
		}
	}	
}
