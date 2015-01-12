using UnityEngine;
using System.Collections;

public class CharacterStats : MonoBehaviour {

	public int LifePoints = 5;
    public const int maxLifePoints = 10;
	public float Energy = 0.5f;

    public WeaponsController Weapons;

    private Animator anim;

    private void RemoveLife(int dmg)
    {
        if (LifePoints > 0)
        {
            LifePoints -= dmg;
            if (LifePoints <= 0)
            {
                LifePoints = 0;
                if (transform.parent != null)
                    StartCoroutine(DieAnimated());
            }

            AudioSource[] audioPlayer = transform.GetChild(2).gameObject.GetComponents<AudioSource>() as AudioSource[];
            audioPlayer[0].Play();
        }
    }

    private void AddLife(int healt)
    {
        LifePoints += healt;
        if(LifePoints>maxLifePoints)
            LifePoints = maxLifePoints;
    }

    private void SetLife(int healt)
    {
        LifePoints = (healt >= 0 ? healt : 0);
    }

    IEnumerator DieAnimated()
    {
        (gameObject.GetComponent<MovableWASD>() as MovableWASD).canMove = false;
        anim = this.GetComponent<Animator>() as Animator;
        anim.SetTrigger("Die");
        Weapons.Equipped.setTrigger("Die");
        yield return new WaitForSeconds(1.2f);
        transform.parent.SendMessage("IsDead");
        (gameObject.GetComponent<MovableWASD>() as MovableWASD).canMove = true;
    }
}
