using UnityEngine;
using System.Collections;

public class WorldMapNumber : MenuElement {

	public string levelName;

	void OnMouseUp(){
		if (unlocked)
			Application.LoadLevel(levelName);
	}

    void OnMouseEnter()
    {
        if (unlocked && transform.childCount > 0)
            transform.GetChild(0).gameObject.SendMessage("OnMouseEnter", SendMessageOptions.DontRequireReceiver);
    }

    void OnMouseExit()
    {
        if (unlocked && transform.childCount > 0)
            transform.GetChild(0).gameObject.SendMessage("OnMouseExit", SendMessageOptions.DontRequireReceiver);
    }

}
