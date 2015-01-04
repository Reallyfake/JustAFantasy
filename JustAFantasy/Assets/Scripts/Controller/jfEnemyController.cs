using UnityEngine;
using System.Collections;

public abstract class jfEnemyController : MonoBehaviour {

    public int HP;
    public GameObject explosion;
    public SpriteRenderer EnemySprite;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("FriendFire"))
        {
            int dmg = (other.gameObject.GetComponent<ShotController>() as ShotController).damage;
			if (!(other.gameObject.GetComponent<ShotController>() as ShotController).resist){
            	Destroy(other.gameObject);
			}
            OnHit(dmg);
        }
    }

    void OnHit(int dmg)
    {
        StopCoroutine(OnHitLight());
        StartCoroutine(OnHitLight());
        HP-=dmg;
        if (HP <= 0)
            OnDie();
    }

    IEnumerator OnHitLight()
    {
        if (EnemySprite != null)
        {
            //Color normal = EnemySprite.material.color;
            EnemySprite.material.color = Color.red;
            yield return new WaitForSeconds(.4f);
            EnemySprite.material.color = Color.white;
        }
    }

    void OnDie()
    {
        Destroy(gameObject);
        if (explosion != null)
            Instantiate(explosion, transform.position, transform.rotation);
    }
}
