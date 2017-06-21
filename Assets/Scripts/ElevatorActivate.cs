using System;
using UnityEngine;
using System.Collections;

public class ElevatorActivate : MonoBehaviour {

    public bool activated;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () 
    {
        if(activated)
        {

        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag=="Player")
        {
            transform.parent.GetComponent<Animator>().enabled = true;
        }
    }

}
