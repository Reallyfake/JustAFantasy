using UnityEngine;
using System.Collections;

public class MenuPlayButton : MonoBehaviour {

    void OnMouseUp()
    {
        Application.LoadLevel(1);
    }
	
}
