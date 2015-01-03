using UnityEngine;
using System.Collections;

public class LifeBar : MonoBehaviour {

	private int currentLife = 5;
	public const int maxLife = 10;

    public Texture2D LifeThumb;

    private GameObject[] LifePoints;

    void Start()
    {
        //transform.position = new Vector3(0, 0, 0);
        LifePoints = new GameObject[maxLife];
        GameObject o;
        for (int i = 0; i < maxLife; i++)
        {
            o = new GameObject("LifePoint" + i);
            o.transform.parent = gameObject.transform;
            o.AddComponent<GUITexture>();
            o.transform.position = new Vector3(0.07f + 0.035f * i, 0.95f, 0f);
            o.transform.localScale = new Vector3(0, 0, 1);
            o.guiTexture.texture = LifeThumb;
            o.guiTexture.pixelInset = new Rect(-19f, -19f, 38f, 38f);
            LifePoints[i] = o;
        }
        setLifePoints(currentLife);
    }

	public void addLifePoint()
    {
		if (currentLife < 10)
			currentLife++;
		setLifePoints (currentLife);
	}

	public void removeLifePoint()
    {
		if (currentLife > 0)
			currentLife--;
		setLifePoints (currentLife);
	}

	public void setLifePoints(int n){
        if (n < 0)
            n = 0;
        if (n > maxLife)
            n = maxLife;
        currentLife = n;
		for (int i=0; i<n; i++) {
			(LifePoints[i].GetComponent<GUITexture> ()as GUITexture).enabled = true;
				}
		for (int i=n; i<maxLife; i++) {
            (LifePoints[i].GetComponent<GUITexture>() as GUITexture).enabled = false;
				}
	}
}
