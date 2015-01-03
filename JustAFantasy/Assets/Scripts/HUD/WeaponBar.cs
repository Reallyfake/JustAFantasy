using UnityEngine;
using System.Collections;

public class WeaponBar : MonoBehaviour {

    private int Ammo;
    private int MaxAmmo;
    private string Name;
    private Texture2D Thumb;

    public GUIText hudAmmo;
    public GUIText hudName;
    public GUITexture hudWeapon;

    private jfWeapon Weapon;

	// Use this for initialization
    /*
	void Awake () {
	    //ammo, name, weapon
        if(hudAmmo == null)
            hudAmmo = transform.GetChild(0).gameObject.GetComponent<GUIText>() as GUIText;
        if(hudName == null)
            hudName = transform.GetChild(1).gameObject.GetComponent<GUIText>() as GUIText;
        if(hudWeapon == null)
            hudWeapon = transform.GetChild(2).gameObject.GetComponent<GUITexture>() as GUITexture;
        hudAmmo.text = "oo/oo";
        hudName.text = "Pistol";
	}
    */

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

        if (hudName != null)
            hudName.text = weapon.weaponName;

        if (weapon.Thumb != null)
        {
            hudWeapon.texture = weapon.Thumb;
        }
    }

    void Update()
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
