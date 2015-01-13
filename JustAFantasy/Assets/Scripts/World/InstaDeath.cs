using UnityEngine;
using System.Collections;

public class InstaDeath : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag.Equals("Player"))
		{
			other.gameObject.SendMessage("DieFast",SendMessageOptions.DontRequireReceiver);
		}
	}

}
