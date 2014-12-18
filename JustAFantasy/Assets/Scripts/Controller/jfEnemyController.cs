using UnityEngine;
using System.Collections;

public abstract class jfEnemyController : MonoBehaviour {

    public int HP;
    public GameObject explosion;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("FriendFire"))
        {
            int dmg = (other.gameObject.GetComponent<ShotController>() as ShotController).damage;
            Destroy(other.gameObject);
            OnHit(dmg);
        }
    }

    void OnHit(int dmg)
    {
        StartCoroutine(OnHitLight());
        HP--;
        if (HP <= 0)
            OnDie();
    }

    IEnumerator OnHitLight()
    {
        Color normal = transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().material.color;
        transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().material.color = Color.green;
        yield return new WaitForSeconds(.4f);
        transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().material.color = normal;
    }

    void OnDie()
    {
        Destroy(gameObject);
        if (explosion != null)
            Instantiate(explosion, transform.position, transform.rotation);
    }
}
