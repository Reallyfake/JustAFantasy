using UnityEngine;
using System.Collections;

public class HUDController : MonoBehaviour {

	private LifeBar lb;

	// Use this for initialization
	void Start () {
		lb = transform.GetChild (0).gameObject.GetComponent<LifeBar> () as LifeBar;
	}
	
	public void setLife(int n){
				lb.setLifePoints (n);
		}

	public void addLife(){
				lb.addLifePoint ();
		}

	public void removeLife(){
				lb.removeLifePoint ();
		}
}
