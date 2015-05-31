using UnityEngine;
using System.Collections;

public class BoxButton : MonoBehaviour {

    public GameObject Object;
    bool activated = false;

    void OnCollisionEnter2D(Collision2D other)
    {
        transform.Find("ButtonEffects").gameObject.SetActive(true);
        Object.GetComponent<Elevator>().activated = true;
        Destroy(this);
    }
}
