using UnityEngine;
using System.Collections;

public class NextLevelButton : MonoBehaviour {

    public string levelName = "MainMenu";
    void OnMouseUp()
    {
        Application.LoadLevel(levelName);
    }
}
