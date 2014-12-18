using UnityEngine;
using System.Collections;

public class CharacterStats : MonoBehaviour {

	public int LifePoints = 5;
    public const int maxLifePoints = 10;
	public float Energy = 0.5f;

    private void RemoveLife(int dmg)
    {
        LifePoints -= dmg;
        if (LifePoints <= 0)
            if (transform.parent != null)
                transform.parent.SendMessage("IsDead");
		AudioSource[] audioPlayer= transform.GetChild(2).gameObject.GetComponents<AudioSource>() as AudioSource[];
		audioPlayer[0].Play();
    }

    private void AddLife(int healt)
    {
        LifePoints += healt;
        if(LifePoints>maxLifePoints)
            LifePoints = maxLifePoints;
    }
}
