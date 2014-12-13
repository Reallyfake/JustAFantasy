using UnityEngine;
using System.Collections;

public class HUDController : MonoBehaviour {

	private LifeBar lb;
    private WeaponBar wb;

	// Use this for initialization
	void Start () {
		lb = transform.GetChild (0).gameObject.GetComponent<LifeBar> () as LifeBar;

        wb = transform.GetChild(2).gameObject.GetComponent<WeaponBar>() as WeaponBar;
	}

    void IsDead()
    {
        if (transform.parent != null)
        {
            transform.parent.SendMessage("IsDead");
        }
    }

    public void setWeapon(jfWeapon w){
        wb.setWeapon(w);
    }

    public void updateAmmo()
    {
        wb.UpdateWeaponAmmo();
    }
	
	public void setLife(int n){
				lb.setLifePoints (n);
		}

	public void addLife(){
				lb.addLifePoint ();
		}

	public void removeLife(){
				lb.removeLifePoint ();
		}
}
