using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	private GameObject WeaponWheel;
    private GameObject Player;
    private GameObject Weapons;
	private HUDController hud;
	private bool is_running = false;
	// Use this for initialization
	void Start () {
		WeaponWheel = transform.GetChild (0).gameObject;
		hud = transform.GetChild (2).gameObject.GetComponent<HUDController> () as HUDController;
        Player = transform.GetChild(3).gameObject;
        Weapons = transform.GetChild(4).gameObject;
        hud.setWeapon(Player.transform.GetChild(3).gameObject.GetComponent<jfWeapon>() as jfWeapon);
	}

    private void exeCommand(string instructions)
    {
        string[] commands = instructions.Split(';');
        foreach (var instruction in commands)
        {
            Debug.Log(instruction);
            //command[0] => funzione, command[1] => parametri
            if (instruction.Length > 2)
            {
                string[] command = instruction.Split(':');
                if (command[0].Equals("Health"))
                {
                    int hp = int.Parse(command[1]);
                    if (hp >= 0)
                    {
                        for (int i = 0; i < hp; i++)
                        {
                            hud.addLife();
                        }
                    }
                    else
                    {
                        for (int i = 0; i > hp; i--)
                        {
                            hud.removeLife();
                        }
                    }
                    Player.SendMessage("AddLife", hp);
                }
                else if (command[0].Equals("Weapon"))
                {
                    string[] parms = command[1].Split(',');
                    KeyCode kc;
                    switch (int.Parse(parms[0]))
                    {
                        case 1: kc = KeyCode.Alpha1;
                            break;
                        case 2: kc = KeyCode.Alpha2;
                            break;
                        case 3: kc = KeyCode.Alpha3;
                            break;
                        default: kc = KeyCode.Alpha0;
                            break;
                    }
                    if ((Player.transform.GetChild(3).gameObject.GetComponent<jfWeapon>() as jfWeapon).fastSelect==kc)
                    {
                        (Player.transform.GetChild(3).gameObject.GetComponent<jfWeapon>() as jfWeapon).reload(int.Parse(parms[1]));
                    }
                    else
                    {
                        for (int i = 0; i < Weapons.transform.childCount; i++)
                        {
                            if ((Weapons.transform.GetChild(i).gameObject.GetComponent<jfWeapon>() as jfWeapon).fastSelect==kc)
                                (Weapons.transform.GetChild(i).gameObject.GetComponent<jfWeapon>() as jfWeapon).reload(int.Parse(parms[1]));
                        }
                    }
                }
            }
        }
    }

    private void OnPlayerHit(int dmg)
    {
        Debug.Log("hit");
        for (int i = 0; i < dmg; i++)
            hud.removeLife();
        Player.SendMessage("RemoveLife", dmg);
    }

    private void IsDead()
    {
        Application.LoadLevel("MainMenu");
    }

    private void OnPlayerHit()
    {
        Debug.Log("Colpito");
        hud.removeLife();
    }

    private void ChangeWeapon(GameObject w)
    {
        Player.SendMessage("ChangeWeapon", w, SendMessageOptions.DontRequireReceiver);
    }

    private void WeaponChanged(GameObject w)
    {
        hud.setWeapon(w.GetComponent<jfWeapon>() as jfWeapon);
        (WeaponWheel.GetComponent<WeaponWheelController>() as WeaponWheelController).changeWeapon(w.GetComponent<jfWeapon>() as jfWeapon);
    }
	
	// Update is called once per frame
	void Update () {
        hud.updateAmmo();
		if (Input.GetKeyDown (KeyCode.P)) {
            Pause();
		}
		if (Input.GetKeyDown (KeyCode.W)) {
            showWW();
		}
		if (Input.GetKeyUp (KeyCode.W)) {
            hideWW();
		}

        if (Input.GetKeyDown(KeyCode.F))
        {
            Player.SendMessage("Shoot");
        }
	}

    private void Pause()
    {
        Time.timeScale = 0;
        transform.GetChild(1).gameObject.SetActive(true);
    }

    private void showWW()
    {
        if (is_running)
        {
            StopCoroutine("DragWWTo");
            is_running = false;
        }
        StartCoroutine("DragWWTo", 0f);
    }

    private void hideWW()
    {
        if (is_running)
        {
            StopCoroutine("DragWWTo");
            is_running = false;
        }
        StartCoroutine("DragWWTo", 1f);
    }

	IEnumerator DragWWTo(float newPos) {
		is_running = true;
		float step = (newPos - WeaponWheel.transform.position.y) / 20;
		for (int f = 0; f < 20; f++) {
			WeaponWheel.transform.position = new Vector2(0, WeaponWheel.transform.position.y + step);
			yield return new WaitForSeconds(.005f);
		}
		WeaponWheel.transform.position = new Vector2 (0, newPos);
		is_running = false;
	}
}
