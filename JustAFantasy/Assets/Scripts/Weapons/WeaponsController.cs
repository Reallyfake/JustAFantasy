using UnityEngine;
using System.Collections;

public class WeaponsController : MonoBehaviour {

    void ChangeWeapon(GameObject w)
    {
        if (transform.parent != null)
            transform.parent.SendMessage("ChangeWeapon", w, SendMessageOptions.DontRequireReceiver);
    }
}
