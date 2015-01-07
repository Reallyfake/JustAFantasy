using UnityEngine;
using System.Collections;

public class EnemyLifeBar : MonoBehaviour {

    public Sprite lifeBarSprite;
    public float barHeight = 2.5f;
    public Vector2 defaultSize = new Vector2(5.0f, 1.0f);

    private jfEnemyController ec;
    private int maxLife;
    private GameObject lifeBar;

	// Use this for initialization
	void Start () {
        ec = gameObject.GetComponent<jfEnemyController>() as jfEnemyController;
        if (ec != null)
            maxLife = ec.HP;
        lifeBar = new GameObject();
        lifeBar.transform.parent = transform;

        lifeBar.AddComponent<SpriteRenderer>();
        (lifeBar.GetComponent<SpriteRenderer>() as SpriteRenderer).sprite = lifeBarSprite;
        lifeBar.transform.localPosition = Vector3.zero + Vector3.up * barHeight;
        lifeBar.transform.localScale = new Vector3(defaultSize.x / 5, defaultSize.y, 1f);

	}
	
	// Update is called once per frame
	void Update () {
        float ratio = Mathf.Abs((float)ec.HP / maxLife);
        lifeBar.transform.localScale = new Vector3((defaultSize.x / 5) * ratio, defaultSize.y, 1f);
	}
}
