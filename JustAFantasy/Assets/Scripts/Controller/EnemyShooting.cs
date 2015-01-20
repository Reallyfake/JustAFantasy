using UnityEngine;
using System.Collections;

public class EnemyShooting : jfEnemyController {

	// shot and it spawn position
	public GameObject shot;
	private Transform shotSpawn;

	// start and end of my sight line
	private Transform sightStart, sightEnd;

	// patrol bounds
	public float xMin,xMax;

	// patrol speed
	public float speed;

	// used to have a fire ratio
	public float nextFire,fireRate;

	public bool notMoving = false;

    private Animator anim;

	// what do I see?
	Collider2D hit;

	void Start(){      
        shotSpawn = transform.GetChild(0).gameObject.transform;
        sightStart = transform.GetChild(1).gameObject.transform;
        sightEnd = transform.GetChild(2).gameObject.transform;
        anim = transform.GetChild(3).gameObject.GetComponent<Animator>() as Animator;
	}

	void Update () {

		// what am i seeing?
		hit=Physics2D.Linecast(sightStart.position, sightEnd.position).collider;

		//have I seen a player?
		if (hit!= null && hit.tag=="Player"){
			Attack();
            anim.SetTrigger("Shoot");
		} else {
			if (!notMoving){
				Patrol ();
			}
		}
	}

    void Patrol()
    {
		if (transform.localPosition.x > xMax || transform.localPosition.x < xMin)
        {
			transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x,xMin,xMax),transform.localPosition.y,transform.localPosition.z);
            transform.Rotate(new Vector2(0, 180));
        }
        transform.Translate(Vector2.right * speed *Time.deltaTime);
    }

	void Attack(){
		if (Time.time> nextFire){
			nextFire= Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}
	}


}
