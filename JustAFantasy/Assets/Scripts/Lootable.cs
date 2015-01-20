using UnityEngine;
using System.Collections;

public class Lootable : MonoBehaviour {

    public string Effect;
    public bool destroyOnContact = true;
	public bool respawn = false;
	public float lastSpawn;
	public float spawnRatio = 10f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
			lastSpawn = Time.time + spawnRatio;
            other.gameObject.SendMessage("lootItem", Effect, SendMessageOptions.DontRequireReceiver);
			if (this.GetComponent<AudioSource>() != null){
				this.GetComponent<AudioSource>().Play();
			}
			if (destroyOnContact){
				if ((GetComponent<SpriteRenderer>() as SpriteRenderer) != null)
					(GetComponent<SpriteRenderer>() as SpriteRenderer).enabled = false;
				if ((GetComponent<CircleCollider2D>() as CircleCollider2D) != null)
					(GetComponent<CircleCollider2D>() as CircleCollider2D).enabled = false;
				if ((GetComponent<BoxCollider2D>() as BoxCollider2D) != null)
					(GetComponent<BoxCollider2D>() as BoxCollider2D).enabled = false;
				if ((GetComponent<PolygonCollider2D>() as PolygonCollider2D) != null)
					(GetComponent<PolygonCollider2D>() as PolygonCollider2D).enabled = false;
				if ((GetComponent<EdgeCollider2D>() as EdgeCollider2D) != null)
					(GetComponent<EdgeCollider2D>() as EdgeCollider2D).enabled = false;
			}
        }
    }

	void Update() {
		if (respawn && Time.time > lastSpawn){
			if ((GetComponent<SpriteRenderer>() as SpriteRenderer) != null)
				(GetComponent<SpriteRenderer>() as SpriteRenderer).enabled = true;
			if ((GetComponent<CircleCollider2D>() as CircleCollider2D) != null)
				(GetComponent<CircleCollider2D>() as CircleCollider2D).enabled = true;
			if ((GetComponent<BoxCollider2D>() as BoxCollider2D) != null)
				(GetComponent<BoxCollider2D>() as BoxCollider2D).enabled = true;
			if ((GetComponent<PolygonCollider2D>() as PolygonCollider2D) != null)
				(GetComponent<PolygonCollider2D>() as PolygonCollider2D).enabled = true;
			if ((GetComponent<EdgeCollider2D>() as EdgeCollider2D) != null)
				(GetComponent<EdgeCollider2D>() as EdgeCollider2D).enabled = true;
		}
	}

}
