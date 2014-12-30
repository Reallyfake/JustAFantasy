using UnityEngine;
using System.Collections;

public class LinearPlatformWRTC : MonoBehaviour {

    public float speed = 1.0f;
    public float delta = 1.0f;
    public Vector2 direction = new Vector2(1, 0);

    public Vector2 center = new Vector2(0, 0);
    public bool isStartingPositionCenter = false;

    public bool moving = true;

	// Use this for initialization
	void Start () {
        if (isStartingPositionCenter)
            center = transform.position;
        direction.Normalize();
	}
	
	// Update is called once per frame
	void Update () {
        if (moving)
        {
            if (Vector2.Distance(transform.position, center) > delta)
                direction = -direction;
            transform.Translate(direction * speed * Time.deltaTime);
        }
	}

    void MoveOn()
    {
        moving = true;
    }

    void MoveOff()
    {
        moving = false;
    }
}
