using UnityEngine;
using System.Collections;

public class NextLevelButton : MenuElement {

    public string levelName = "MainMenu";
    void OnMouseUp()
    {
        Application.LoadLevel(levelName);
    }
}
