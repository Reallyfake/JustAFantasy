using UnityEngine;
using System.Collections;

public class BossFoodController : jfEnemyController {


	//what should i ShotController and where?
	public GameObject shot;
	public Transform shotSpawn;
    public GameOverMenu gameOverMenu;

	// my transform
	public Transform tf;

	// fire ratio
	public float fireRate;

	// speed, x bounds
	public float speed,xMin,xMax;
	
	private float nextFire;

	int initialHP;

	// Use this for initialization
	void Start () {

		tf = GetComponent<Transform> () as Transform;
		initialHP = HP;
	
	}
	
	// Update is called once per frame
	void Update () {

		// move horizaly between bounds
		tf.position=new Vector2 (Mathf.PingPong(Time.time * speed,xMax-xMin) +xMin , tf.position.y);

		// shoot every fire ratio time
		if (Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, Quaternion.AngleAxis(270f, Vector3.forward));
			audio.Play ();
		}
	
	}

    void OnDestroy()
    {
        gameOverMenu.SendMessage("StageClear");
    }

	public void RefillHP(){
		if (HP < initialHP/2){
			HP = (int) initialHP/2;
		} else {
			HP = (int) initialHP;
		}
	}
}
