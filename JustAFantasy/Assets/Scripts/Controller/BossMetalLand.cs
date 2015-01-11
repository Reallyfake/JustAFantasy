using UnityEngine;
using System.Collections;

public class BossMetalLand : jfEnemyController {

	//don't touch the fucking numbers, please
	public float jumpHeight = 3f;
	// My transform
	Transform tf;

	// Target transform
	Transform target;
	
	// target position
	float xt,yt;

	public float timeReach=2f;

	//my position
	float xin,yin;
	
	//relative position of target wrt my coordinates
	float xrel,yrel;

	public float jumpRatio = 3f;

	 float nextJump;

	public float shotRatio = 1f;
	
	float nextShot;

	float initialHP;

	private Rigidbody2D rb;

	public GameObject shot;

	public GameOverMenu gameOverMenu;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> () as Transform;
		rb = GetComponent<Rigidbody2D>() as Rigidbody2D;
		initialHP = HP;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextJump){
			jumpKnight();
		}
		if (rb.velocity.y==0f){
			rb.velocity = Vector2.zero;
		}
		if ((HP < (initialHP / 2f)) && (Time.time > nextShot)){
			ShootPrecise();
		}
	}

	void ShootPrecise(){
		nextShot = Time.time + shotRatio;
		Transform target;
		// find player position
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform> () as Transform;
		Vector2 dir = target.position - tf.position;
		
		// calculate rotation of the turret to look at the target
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		
		Instantiate(shot, tf.position, Quaternion.AngleAxis(angle, Vector3.forward));
		
	}

	void jumpKnight(){

		nextJump = Time.time + jumpRatio;
		
		xin = tf.position.x;
		yin = tf.position.y;
		target=GameObject.FindGameObjectWithTag("Player").GetComponent<Transform> () as Transform;
		xt = target.position.x;
		yt = target.position.y;
		xrel = (xt - xin);
		yrel = (yt - yin);
		
		
		rb.AddForce(transform.up * jumpHeight * 10, ForceMode2D.Impulse);
		float vel = xrel/timeReach;
		rb.AddForce(transform.right * vel, ForceMode2D.Impulse);
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag.Equals("FriendFire"))
		{
			int dmg = (other.gameObject.GetComponent<ShotController>() as ShotController).damage;
			if (!(other.gameObject.GetComponent<ShotController>() as ShotController).resist){
				Destroy(other.gameObject);
			}
			OnHit(dmg);
		}

		//if hits player, he jumps away
		if (other.gameObject.tag.Equals("Player")){
			rb.velocity = Vector2.zero;
			jumpKnight();
		}
	}

	void OnDestroy()
	{
		gameOverMenu.SendMessage("StageClear");
	}
}
