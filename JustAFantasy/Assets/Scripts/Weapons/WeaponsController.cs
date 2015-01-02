using UnityEngine;
using System.Collections;

public class WeaponsController : MonoBehaviour {

    public jfWeapon Equipped;

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
    }
}
