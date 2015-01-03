using UnityEngine;
using System.Collections;

public class WeaponCatThrower : jfWeapon {

    public Transform sightStart,sightEnd;
	public Transform sightStartUp,sightEndUp;

	public float offset = 0.5f;
	LineRenderer ln;
	public ParticleSystem ps;
    

	// Use this for initialization
	void Start () {
        base.OnStart();
		ln = GetComponent<LineRenderer> () as LineRenderer;
	}

    public override void OpenFire()
    {
        if(Ammo>0 || Ammo == -1)
        {
            //if (Input.GetKey(KeyCode.UpArrow))
            //{
            //    GameObject o = Instantiate(shoot, transform.position, Quaternion.AngleAxis(90, Vector3.forward)) as GameObject;
            //}
            //else
            //{
                if (anim != null)
                    anim.SetTrigger("isShooting");
			if (Input.GetKey(KeyCode.UpArrow)) {
				Collider2D hit=Physics2D.Linecast(sightStartUp.position, sightEndUp.position).collider;
				Vector3 end;
				if (hit !=null){
					end = new Vector3 (sightStartUp.position.x,hit.transform.position.y,0f);
					hit.SendMessage("OnHit",1, SendMessageOptions.DontRequireReceiver);
				} else {
					end = sightEndUp.position;
				}
				ln.SetVertexCount(2);
				ln.SetPosition(0,sightStartUp.position);
				ln.SetPosition(1,end);
				ln.enabled =true;
				end.x = end.x - offset;
				ps.transform.position=end;
				ps.gameObject.SetActive(true);

			} else {

				Collider2D hit=Physics2D.Linecast(sightStart.position, sightEnd.position).collider;
				Vector3 end;
				if (hit !=null){
					end = new Vector3 (hit.transform.position.x,sightStart.position.y,0f);
					hit.SendMessage("OnHit",1, SendMessageOptions.DontRequireReceiver);
				} else {
					end = sightEnd.position;
				}
				ln.SetVertexCount(2);
				ln.SetPosition(0,sightStart.position);
				ln.SetPosition(1,end);
				ln.enabled =true;
				end.x = end.x - offset;
				ps.transform.position=end;
				ps.gameObject.SetActive(true);
			}
                //GameObject o = Instantiate(shoot, transform.position, transform.rotation) as GameObject;
                //if (transform.lossyScale.x < 0)
                  //  (o.GetComponent<LinearMover>() as LinearMover).speed *= -1;
            //}
            //lastShotTime = Time.time;
            if(Ammo != -1)
                Ammo--;
        }
		if (Input.GetKey(KeyCode.F) && (Ammo>0 || Ammo == -1)){
			Invoke("OpenFire",0.01f);
		} else {
			ps.gameObject.SetActive(false);
			ln.SetVertexCount(0);
		}
    }
}
