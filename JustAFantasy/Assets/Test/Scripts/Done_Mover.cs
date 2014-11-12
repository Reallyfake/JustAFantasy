using UnityEngine;
using System.Collections;

public class Done_Mover : MonoBehaviour
{
	public float speed;

	Rigidbody2D rb = null;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D> () as Rigidbody2D;
		rb.velocity = transform.right * speed;
	}
}
