using UnityEngine;
using System.Collections;

public class WeaponCatThrower : jfWeapon {

    public Transform sightStart,sightEnd;
	public Transform sightStartUp,sightEndUp;

	public float offset = 0.5f;
	LineRenderer ln;
	public ParticleSystem ps;
	private AudioSource audioWeapon;


	// Use this for initialization
	void Start () {
        base.OnStart();
		ln = GetComponent<LineRenderer> () as LineRenderer;
		audioWeapon = this.GetComponent<AudioSource>() as AudioSource;
	}

    public override void OpenFire()
    {
        if(Ammo>0 || Ammo == -1)
        {
			if (audioWeapon != null && !audioWeapon.isPlaying){
				audioWeapon.Play();
			}

			if (Input.GetKey(KeyCode.UpArrow) || Input.GetAxis("JoyY")>=0.1f) {

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
				ps.transform.rotation = Quaternion.AngleAxis(90f, Vector3.right);
				ps.gameObject.SetActive(true);
                if (anim != null)
                    anim.SetTrigger("isShootingUp");

			} else {
                if (anim != null)
                    anim.SetTrigger("isShooting");
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
                
            if(Ammo != -1)
                Ammo--;
        }
		if ((Input.GetKey(KeyCode.F)|| Input.GetButton("Fire3Joy")) && (Ammo>0 || Ammo == -1)){
			Invoke("OpenFire",0.01f);
		} else {
			ps.gameObject.SetActive(false);
			ln.SetVertexCount(0);
			audioWeapon.Stop();
		}
    }
}
