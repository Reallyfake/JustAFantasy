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
        hud.setWeapon(Player.transform.GetChild(1).gameObject.GetComponent<jfWeapon>() as jfWeapon);
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

    private void WeaponChanged(jfWeapon w)
    {
        hud.setWeapon(w);
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
            (Player.transform.GetChild(1).gameObject.GetComponent<jfWeapon>() as jfWeapon).openFire();
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
            StopCoroutine("DragWWTo");
        StartCoroutine("DragWWTo", 0f);
    }

    private void hideWW()
    {
        if (is_running)
            StopCoroutine("DragWWTo");
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
