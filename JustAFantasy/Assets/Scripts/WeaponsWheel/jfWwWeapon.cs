using UnityEngine;
using System.Collections;

public class jfWwWeapon : MonoBehaviour {

	public GameObject jf_Weapon;

	void OnMouseEnter(){
		jfWeapon w;
		string msg;
		if (jf_Weapon != null && (w = jf_Weapon.GetComponent("jfWeapon") as jfWeapon) != null) {
			msg = w.weaponName + "\n";
			if(w.Ammo == -1)
				msg += "oo/oo";
			else if(w.maxAmmo == -1)
				msg += w.Ammo.ToString() + "/oo";
			else
				msg += w.Ammo.ToString() + "/" + w.maxAmmo.ToString();

				}
		else
			msg = "N/A\nN/A";
		transform.parent.GetChild (1).guiText.text = msg;
		}

}
