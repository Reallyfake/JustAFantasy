using UnityEngine;
using System.Collections;

public class DippingInk : MonoBehaviour {

	public GameObject shotSpawn;
	public GameObject shoot;
	
	public float lastDrop, dropRatio, angleShoot; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > lastDrop){
			Instantiate(shoot, shotSpawn.transform.position, Quaternion.AngleAxis(angleShoot, Vector3.forward));
			lastDrop=Time.time + dropRatio;
		}
	}
}
