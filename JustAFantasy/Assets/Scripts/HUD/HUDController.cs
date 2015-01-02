using UnityEngine;
using System.Collections;

public class HUDController : MonoBehaviour {

	public LifeBar lb;
    public WeaponBar wb;

	// Use this for initialization
    void Awake()
    {
        if(lb == null)
            lb = transform.GetChild(0).gameObject.GetComponent<LifeBar>() as LifeBar;
        if(lb == null)
            wb = transform.GetChild(2).gameObject.GetComponent<WeaponBar>() as WeaponBar;
    }

    void IsDead()
    {
        
    }

    public void setWeapon(jfWeapon w){
        if(wb != null)
            wb.setWeapon(w);
    }

    public void updateAmmo()
    {
        wb.UpdateWeaponAmmo();
    }

    public void setLife(int n)
    {
        lb.setLifePoints(n);
    }

    public void addLife()
    {
        lb.addLifePoint();
    }

    public void removeLife()
    {
        lb.removeLifePoint();
    }
}
