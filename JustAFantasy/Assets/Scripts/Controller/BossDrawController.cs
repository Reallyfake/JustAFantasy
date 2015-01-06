using UnityEngine;
using System.Collections;

public class BossDrawController : jfEnemyController {

	Transform tf;
	public Transform shotSpawn;
	public GameObject shotPrecise;
	SpriteRenderer sp;
	float colorRandomChoice,shotRandomChoice;
	public float colorTime,colorRatio;
	public float shotTime,shotRatio;
	Color invictus;


	// Use this for initialization
	void Start () {
		sp=this.GetComponent<SpriteRenderer>() as SpriteRenderer;
		invictus = sp.material.color;
		tf= this.GetComponent<Transform>() as Transform;
	}

	// Update is called once per frame
	void Update () {
		if (Time.time > colorTime){
			colorRandomChoice = Random.Range(0f,5.5f);
			colorTime=Time.time + colorRatio;
		}

		if (colorRandomChoice >= 0f && colorRandomChoice < 1f){
			sp.material.color = Color.gray;
		} else if (colorRandomChoice >= 1f && colorRandomChoice < 2f){
			sp.material.color = Color.blue;
		} else if (colorRandomChoice >= 2f && colorRandomChoice < 3f){
			sp.material.color = Color.red;
		}else if (colorRandomChoice >= 3f && colorRandomChoice < 4f){
			sp.material.color = Color.green;
		}else if (colorRandomChoice >= 4f && colorRandomChoice < 5f){
			sp.material.color = Color.yellow;
		} else if (colorRandomChoice >= 5f && colorRandomChoice < 6f){
			sp.material.color = invictus;
		}

		if (Time.time > shotTime){
			shotRandomChoice = Random.Range(0f,2.5f);
			shotTime=Time.time + shotRatio;	

			if (shotRandomChoice >= 0f && shotRandomChoice < 1f){
				ShootPrecise();
			} else if (shotRandomChoice >= 1f && shotRandomChoice < 2f){
				ShootThree();
			} else if (shotRandomChoice >= 2f && shotRandomChoice < 3f){
				ShootAll();
			}
		
		}
	}

	void ShootPrecise(){
		Debug.Log("sparo preciso " + Time.time);
		Transform target;
		// find player position
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform> () as Transform;
		Vector2 dir = target.position - tf.position;
		
		// calculate rotation of the turret to look at the target
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

		Instantiate(shotPrecise, shotSpawn.position, Quaternion.AngleAxis(angle, Vector3.forward));

	}

	void ShootThree(){
		Debug.Log("sparo a 3 " + Time.time);
		Instantiate(shotPrecise, shotSpawn.position, Quaternion.AngleAxis(235, Vector3.forward));
		Instantiate(shotPrecise, shotSpawn.position, Quaternion.AngleAxis(270, Vector3.forward));
		Instantiate(shotPrecise, shotSpawn.position, Quaternion.AngleAxis(295, Vector3.forward));
	}

	void ShootAll(){
		Debug.Log("sparo multiplo " + Time.time);
		float angle = 45f;
		for (int i=0;i<8;i++){
			Instantiate(shotPrecise, shotSpawn.position, Quaternion.AngleAxis(angle*i, Vector3.forward));
		}
	}


}
