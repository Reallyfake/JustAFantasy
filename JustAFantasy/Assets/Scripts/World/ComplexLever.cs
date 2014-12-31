using UnityEngine;
using System.Collections;

public class ComplexLever : MonoBehaviour {

    public GameObject[] targets;
    public bool onRight = false;
    public string actionRight = "Active";
	public string actionRightMessage = null;
	public string actionLeft = "DeActive";
	public string actionLeftMessage = null;

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
				for (int i=0; i < targets.Length ; i++){
		            if (targets[i] != null)
						if (actionLeftMessage==null){
		                	targets[i].SendMessage(actionLeft, SendMessageOptions.DontRequireReceiver);
					} else{
						targets[i].SendMessage(actionLeft,actionLeftMessage, SendMessageOptions.DontRequireReceiver);
					}
				}
	            (GetComponent<SpriteRenderer>() as SpriteRenderer).sprite = leftLever;
			} else {
				onRight = true;
				for (int i=0; i < targets.Length ; i++){
					if (targets[i] != null)
						if (actionRightMessage==null){
							targets[i].SendMessage(actionRight, SendMessageOptions.DontRequireReceiver);
						} else{
							targets[i].SendMessage(actionRight,actionRightMessage, SendMessageOptions.DontRequireReceiver);
						}
				}
				(GetComponent<SpriteRenderer>() as SpriteRenderer).sprite = rightLever;
			}
        }
    }
}
