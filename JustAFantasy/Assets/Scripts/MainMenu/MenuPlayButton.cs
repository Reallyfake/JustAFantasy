using UnityEngine;
using System.Collections;

public class MenuPlayButton : MenuElement {

    void OnMouseUp()
    {
        Application.LoadLevel(2);
    }
	
}
