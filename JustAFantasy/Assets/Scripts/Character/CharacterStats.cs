using UnityEngine;
using System.Collections;

public class CharacterStats : MonoBehaviour {

	public int LifePoints = 5;
	public float Energy = 0.5f;

    private void RemoveLife(int dmg)
    {
        LifePoints -= dmg;
        if (LifePoints <= 0)
            if (transform.parent != null)
                transform.parent.SendMessage("IsDead");
    }
}
