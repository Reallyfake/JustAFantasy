using UnityEngine;
using System.Collections;

public class TriggerZone : MonoBehaviour {

	public GameObject[] targets;
	public string action = "Active";

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag.Equals("Player"))
		{
			for (int i=0; i < targets.Length ;i++){
				if (targets[i] != null)
					(targets[i] as GameObject).SendMessage(action, SendMessageOptions.DontRequireReceiver);
			}
			Destroy(gameObject);
		}
	}
}
