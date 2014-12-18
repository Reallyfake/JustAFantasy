using UnityEngine;
using System.Collections;

public class SimpleButton : MonoBehaviour {

    public GameObject target;
    public Object param;
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
                if (param != null)
                    target.SendMessage(action, param, SendMessageOptions.DontRequireReceiver);
                else
                    target.SendMessage(action, SendMessageOptions.DontRequireReceiver);
            (GetComponent<SpriteRenderer>() as SpriteRenderer).sprite = buttonDown;
        }
    }
}
