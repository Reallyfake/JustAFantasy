using UnityEngine;
using System.Collections;

public class WeaponBar : MonoBehaviour {

    private int Ammo;
    private int MaxAmmo;
    private string Name;
    private Texture2D Thumb;

    private GUIText hudAmmo;
    private GUIText hudName;
    private GUITexture hudWeapon;

    private jfWeapon Weapon;

	// Use this for initialization
	void Start () {
	    //ammo, name, weapon
        hudAmmo = transform.GetChild(0).gameObject.GetComponent<GUIText>() as GUIText;
        hudName = transform.GetChild(1).gameObject.GetComponent<GUIText>() as GUIText;
        hudWeapon = transform.GetChild(2).gameObject.GetComponent<GUITexture>() as GUITexture;
        hudAmmo.text = "oo/oo";
        hudName.text = "Pistol";
	}

    public void setWeapon(jfWeapon weapon)
    {
        Weapon = weapon;
        if(Weapon.Ammo == -1)
            hudAmmo.text = "oo/";
        else
            hudAmmo.text = Weapon.Ammo.ToString() + "/";
        if (Weapon.maxAmmo == -1)
            hudAmmo.text += "oo";
        else
            hudAmmo.text += Weapon.Ammo.ToString();

        hudName.text = weapon.weaponName;
        
    }

    public void UpdateWeaponAmmo()
    {
        if (Weapon.Ammo == -1)
            hudAmmo.text = "oo/";
        else
            hudAmmo.text = Weapon.Ammo.ToString() + "/";
        if (Weapon.maxAmmo == -1)
            hudAmmo.text += "oo";
        else
            hudAmmo.text += Weapon.Ammo.ToString();
    }
	
}
