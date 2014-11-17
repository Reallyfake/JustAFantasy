using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	public GameObject explosion;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "enemy") {
						Instantiate (explosion, transform.position, transform.rotation);
						Destroy (other.gameObject);
						Destroy (gameObject);
				}
	}
}