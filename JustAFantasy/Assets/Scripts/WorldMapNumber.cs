using UnityEngine;
using System.Collections;

public class WorldMapNumber : MenuElement {

	public string levelName;

	void OnMouseUp(){
		Application.LoadLevel(levelName);
	}

    void OnMouseEnter()
    {
        if (transform.childCount > 0)
            transform.GetChild(0).gameObject.SendMessage("OnMouseEnter", SendMessageOptions.DontRequireReceiver);
    }

    void OnMouseExit()
    {
        if (transform.childCount > 0)
            transform.GetChild(0).gameObject.SendMessage("OnMouseExit", SendMessageOptions.DontRequireReceiver);
    }

}
