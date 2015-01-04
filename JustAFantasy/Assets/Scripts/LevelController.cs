using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

    public GameObject Player;
	public HUDController hud;
    public GameObject PauseMenu;
	public Vector3 lastPosition;
    public GameObject Weapons;


    private bool is_running = false;

	// Use this for initialization
	void Start () {
        
        CharacterInteractions ci = Player.GetComponent<CharacterInteractions>() as CharacterInteractions;
        if (ci != null && ci.Weapons != null && ci.Weapons.Equipped != null)
        {
            Debug.Log(ci.Weapons.Equipped.name);
            hud.setWeapon(ci.Weapons.Equipped);
        }
		
        lastPosition = Player.transform.localPosition;
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
                    for (int i = 0; i < Weapons.transform.childCount; i++)
                    {
                        if ((int)(Weapons.transform.GetChild(i).gameObject.GetComponent<jfWeapon>() as jfWeapon).fastSelect - 48 == int.Parse(parms[0]))
                            (Weapons.transform.GetChild(i).gameObject.GetComponent<jfWeapon>() as jfWeapon).reload(int.Parse(parms[1]));
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

	private void CheckPoint(Vector3 pos)
	{
		Debug.Log ("chiamato");
		lastPosition = pos;
	}

    private void IsDead()
    {
		Player.transform.localPosition = lastPosition;
        Player.rigidbody2D.MovePosition(lastPosition);
        Player.rigidbody2D.velocity = Vector2.zero;
        Player.rigidbody2D.angularVelocity = 0;

        hud.setLife(5);
        Player.SendMessage("AddLife", 5);

       // Application.LoadLevel("MainMenu");
    }

    private void OnPlayerHit()
    {
        Debug.Log("Colpito");
        hud.removeLife();
    }

    private void WeaponChanged(GameObject w)
    {
        hud.setWeapon(w.GetComponent<jfWeapon>() as jfWeapon);
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
            Pause();
		}

        if (Input.GetKeyDown(KeyCode.F))
        {
            Player.SendMessage("Shoot");
        }
	}

    private void Pause()
    {
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
    }

}
