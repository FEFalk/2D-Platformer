using UnityEngine;
using System.Collections;

public class BoxButton : MonoBehaviour {

    public GameObject Object;
    bool activated = false;

    void OnCollisionEnter2D(Collision2D other)
    {
        if(activated == false)
             Object.GetComponent<ObstacleHandler>().activated = true;
        activated = true;
    }
}
