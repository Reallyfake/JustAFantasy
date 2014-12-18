using UnityEngine;
using System.Collections;

public class MenuCreditButton : MonoBehaviour {

    public GameObject cube;

	// Use this for initialization
    void OnMouseUp()
    {
        StartCoroutine(Rotate());
    }

    IEnumerator Rotate()
    {
        for (int f = 0; f < 90; f++)
        {
            cube.transform.Rotate(0f, -1f, 0f);
            yield return new WaitForSeconds(.005f);
        }
    }
}
