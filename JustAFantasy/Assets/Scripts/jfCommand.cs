using UnityEngine;
using System.Collections;

public class jfCommand : MonoBehaviour {

    public string Effect;
    public bool destroyOnContact = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            other.gameObject.SendMessage("lootItem", Effect, SendMessageOptions.DontRequireReceiver);
            if (destroyOnContact)
                Destroy(gameObject);
        }
    }
}
