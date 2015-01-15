using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

	public float lifeTime = 0.7f;
	
	void Update()
	{
		lifeTime -= Time.deltaTime;
		if (lifeTime < 0)
			Destroy(gameObject);
	}
}
