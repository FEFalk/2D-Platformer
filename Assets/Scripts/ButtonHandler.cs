using UnityEngine;
using System.Collections;

public class ButtonHandler : MonoBehaviour {
    public GameObject Object;
    public bool buttonActivate = false;
	
	// Update is called once per frame
	void Update () {
        if (buttonActivate)
        {
            Object.GetComponent<ObstacleHandler>().activated = true;
            buttonActivate = false;
        }
	}

}
