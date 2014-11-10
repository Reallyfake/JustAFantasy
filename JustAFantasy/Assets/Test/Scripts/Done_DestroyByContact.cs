using UnityEngine;
using System.Collections;

public class Done_DestroyByContact : MonoBehaviour
{
	public GameObject explosion;

	void OnTriggerEnter (Collider other)
	{
		Debug.Log("Colpito");
		if (other.tag == "enemy") {
						Instantiate (explosion, transform.position, transform.rotation);
						Destroy (other.gameObject);
						Destroy (gameObject);
				}
	}
}