using UnityEngine;
using System.Collections;

public class MenuElement : MonoBehaviour {

    public MenuElement selectOnUp;
    public MenuElement selectOnDown;
    public MenuElement selectOnLeft;
    public MenuElement selectOnRight;
    public MenuElement selectOnEnter;
    public float lastKey;
    public float keyRatio = 0.5f;
    public float neverKey;

    public bool selected = false;
	public bool unlocked = true;
	public int level = -1;

    void Start()
    {
        keyRatio = 0.5f;
        if(selected)
            gameObject.SendMessage("OnMouseEnter", SendMessageOptions.DontRequireReceiver);
		if (level >= 0 && GameObject.FindGameObjectWithTag("GameControllerAll") != null){
			unlocked = (GameObject.FindGameObjectWithTag("GameControllerAll").GetComponent<GameController>() as GameController).gs.levelUnlocked[level];
		}
    }

    void selectThis()
    {
        selected = true;
        gameObject.SendMessage("OnMouseEnter", SendMessageOptions.DontRequireReceiver);
    }

    void deselectThis()
    {
        selected = false;
        gameObject.SendMessage("OnMouseExit", SendMessageOptions.DontRequireReceiver);
    }

    void OnMouseEnter()
    {
        selected = true;
    }

    void OnMouseExit()
    {
        selected = false;
    }

	// Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            neverKey += 0.01f;
        }
        else {
            neverKey = Time.time;
        }
        if (selected && neverKey > lastKey)
        {
            // return;
            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetAxis("JoyX") <= -0.1f)
            {
                lastKey = neverKey + keyRatio;
                if (selectOnLeft != null && selectOnLeft.unlocked)
                {
                    selectOnLeft.selected = true;
                    selectOnLeft.lastKey = Time.time + keyRatio;
                    selectOnLeft.SendMessage("OnMouseEnter", SendMessageOptions.DontRequireReceiver);
                    selected = false;
                    gameObject.SendMessage("OnMouseExit", SendMessageOptions.DontRequireReceiver);
                }
            }
            else if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetAxis("JoyX") >= 0.1f)
            {
                if (selectOnRight != null && selectOnRight.unlocked)
                {
                    selectOnRight.lastKey = neverKey + keyRatio;
                    selectOnRight.selected = true;
                    selectOnRight.SendMessage("OnMouseEnter", SendMessageOptions.DontRequireReceiver);
                    selected = false;
                    gameObject.SendMessage("OnMouseExit", SendMessageOptions.DontRequireReceiver);
                }
            }
            else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetAxis("JoyY")>=0.1f)
            {
                if (selectOnUp != null && selectOnUp.unlocked)
                {
                    selectOnUp.lastKey = neverKey + keyRatio;
                    selectOnUp.selected = true;
                    selectOnUp.SendMessage("OnMouseEnter", SendMessageOptions.DontRequireReceiver);
                    selected = false;
                    gameObject.SendMessage("OnMouseExit", SendMessageOptions.DontRequireReceiver);
                }
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetAxis("JoyY") <= -0.1f)
            {
                if (selectOnDown != null && selectOnDown.unlocked)
                {
                    selectOnDown.lastKey = neverKey + keyRatio;
                    selectOnDown.selected = true;
                    selectOnDown.SendMessage("OnMouseEnter", SendMessageOptions.DontRequireReceiver);
                    selected = false;
                    gameObject.SendMessage("OnMouseExit", SendMessageOptions.DontRequireReceiver);
                    Debug.Log("Jonny è stato quì");
                }
            }
            else if (Input.GetKeyDown(KeyCode.Return) || Input.GetButton("Fire1Joy"))
            {
                if (selectOnEnter != null)
                {
                    selectOnEnter.lastKey = neverKey + keyRatio;
                    selectOnEnter.selected = true;
                    selectOnEnter.SendMessage("OnMouseEnter", SendMessageOptions.DontRequireReceiver);
                    selected = false;
                    gameObject.SendMessage("OnMouseExit", SendMessageOptions.DontRequireReceiver);
                }
                
                gameObject.SendMessage("OnMouseUp", SendMessageOptions.DontRequireReceiver);
            }

        }
    }
}
