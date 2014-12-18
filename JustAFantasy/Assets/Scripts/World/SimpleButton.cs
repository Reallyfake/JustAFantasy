using UnityEngine;
using System.Collections;

public class SimpleButton : MonoBehaviour {

    public GameObject target;
    public bool pressed = false;
    public string action = "Active";

    public Sprite buttonUp;
    public Sprite buttonDown;

	// Use this for initialization
	void Start () {
        if (pressed)
            (GetComponent<SpriteRenderer>() as SpriteRenderer).sprite = buttonDown;
        else
            (GetComponent<SpriteRenderer>() as SpriteRenderer).sprite = buttonUp;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player") && !pressed)
        {
            pressed = true;
            if (target != null)
                target.SendMessage(action, SendMessageOptions.DontRequireReceiver);
            (GetComponent<SpriteRenderer>() as SpriteRenderer).sprite = buttonDown;
            if ((GetComponent<CircleCollider2D>() as CircleCollider2D) != null)
                (GetComponent<CircleCollider2D>() as CircleCollider2D).enabled = false;
            if ((GetComponent<BoxCollider2D>() as BoxCollider2D) != null)
                (GetComponent<BoxCollider2D>() as BoxCollider2D).enabled = false;
        }
    }
}
