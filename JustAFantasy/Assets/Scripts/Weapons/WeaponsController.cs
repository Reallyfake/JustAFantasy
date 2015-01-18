using UnityEngine;
using System.Collections;

public class WeaponsController : MonoBehaviour {

    public jfWeapon Equipped;
    public jfWeapon DefaultWeapon;

    void ChangeWeapon(GameObject w)
    {
        Equipped.renderer.enabled = false;
        Equipped = w.GetComponent<jfWeapon>() as jfWeapon;
        Equipped.renderer.enabled = true;
        if (transform.parent != null)
            transform.parent.SendMessage("ChangeWeapon", w, SendMessageOptions.DontRequireReceiver);
    }

    public void shoot()
    {
        Equipped.SendMessage("Shoot");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.localPosition -= Vector3.up * 0.5f;
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            transform.localPosition += Vector3.up * 0.5f;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            for (int i = transform.childCount-1; i >= 0; i--)
            {
                if ((int)(transform.GetChild(i).gameObject.GetComponent<jfWeapon>() as jfWeapon).fastSelect == (int)Equipped.fastSelect - 1)
                {
                    ChangeWeapon(transform.GetChild(i).gameObject);
                    if (Equipped.Ammo != 0)
                        break;
                }
            }
            if (Equipped.Ammo == 0 && DefaultWeapon != null)
                ChangeWeapon(DefaultWeapon.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            jfWeapon actual = Equipped;
            for (int i = 0; i < transform.childCount; i++)
            {
                if ((int)(transform.GetChild(i).gameObject.GetComponent<jfWeapon>() as jfWeapon).fastSelect == (int)Equipped.fastSelect + 1)
                {
                    ChangeWeapon(transform.GetChild(i).gameObject);
                    if(Equipped.Ammo != 0)
                        break;
                }
            }
            if (Equipped.Ammo == 0 && DefaultWeapon != null)
                ChangeWeapon(actual.gameObject);
        }
    }
}
