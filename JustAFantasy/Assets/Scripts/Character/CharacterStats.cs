using UnityEngine;
using System.Collections;

public class CharacterStats : MonoBehaviour {

	public int LifePoints = 5;
	public float Energy = 0.5f;

	// Use this for initialization
	void Start () {
	    
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("EnemyFire"))
        {
            Destroy(other.gameObject);
            transform.parent.SendMessage("OnPlayerHit");
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
