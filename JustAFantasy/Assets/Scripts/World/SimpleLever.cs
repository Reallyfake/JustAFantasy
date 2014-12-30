using UnityEngine;
using System.Collections;

public class SimpleLever : MonoBehaviour {

    public GameObject target;
    public bool onRight = false;
    public string actionRight = "Active";
	public string actionLeft = "DeActive";

    public Sprite rightLever;
    public Sprite leftLever;
	public LayerMask lay;

	// Use this for initialization
	void Start () {
        if (onRight)
            (GetComponent<SpriteRenderer>() as SpriteRenderer).sprite = rightLever;
        else
            (GetComponent<SpriteRenderer>() as SpriteRenderer).sprite = leftLever;
	}

	void Update(){
   
		if (Physics2D.OverlapCircle(transform.position,0.6f,lay) && Input.GetKeyDown(KeyCode.D))
        {

			if (onRight){
	            onRight = false;
	            if (target != null)
	                target.SendMessage(actionLeft, SendMessageOptions.DontRequireReceiver);
	            (GetComponent<SpriteRenderer>() as SpriteRenderer).sprite = leftLever;
			} else {
				onRight = true;
				if (target != null)
					target.SendMessage(actionRight, SendMessageOptions.DontRequireReceiver);
				(GetComponent<SpriteRenderer>() as SpriteRenderer).sprite = rightLever;
			}
        }
    }
}
