using UnityEngine;
using System.Collections;

public class WeaponSum : MonoBehaviour {

    public GameObject WeaponItem;
    public WeaponsController WeaponsCtrl;

    private GameObject[] Weapons;

    public KeyCode ShowHide;
    private bool show = true;

    void Start()
    {
        Weapons = new GameObject[WeaponsCtrl.transform.childCount];
        for (int i = 0; i < WeaponsCtrl.transform.childCount; i++)
        {
            GameObject o = Instantiate(WeaponItem) as GameObject;
            jfWeapon w = WeaponsCtrl.transform.GetChild(i).gameObject.GetComponent<jfWeapon>() as jfWeapon;
            o.transform.position = new Vector3(0.15f + 0.0875f * (((int)w.fastSelect - 48) - 1), 0.1f, 0);
            (o.GetComponent<WeaponBar>() as WeaponBar).setWeapon(w);
            o.transform.parent = transform;
            o.name = "Weapon" + ((int)w.fastSelect - 48);
            Weapons[i] = o;
        }
    }

    void Update()
    {
		if (Input.GetKeyDown(ShowHide) || Input.GetButtonDown("Weapon"))
        {
            show = !show;
            if (show)
            {
                for (int i = 0; i < Weapons.Length; i++)
                {
                    Weapons[i].SetActive(true);
                }
            }else
            {
                for(int i=0; i<Weapons.Length; i++)
                {
                    Weapons[i].SetActive(false);
                }
            }
        }
    }
}
