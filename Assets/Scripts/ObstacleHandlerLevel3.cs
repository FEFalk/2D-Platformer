using UnityEngine;
using System.Collections;

public class ObstacleHandlerLevel3 : MonoBehaviour {
    public bool activated = false;

    void Update()
    {
        if (activated)
        {
            StartCoroutine(Activate());

        }
    }
    IEnumerator Activate()
    {
        GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(2);
        GetComponent<Collider2D>().enabled = false;
        activated = false;
    }
}
