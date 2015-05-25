using UnityEngine;
using System.Collections;

public class ButtonHandler : MonoBehaviour {
    public GameObject Object;
    public bool buttonActivate = false;
    public bool greenButtonActivate = false;
	
	// Update is called once per frame
	void Update () {
        if (buttonActivate)
        {
            Object.GetComponent<ObstacleHandler>().activated = true;
            buttonActivate = false;
        }
        //if (greenButtonActivate)
        //{ 
        //    Object.GetComponent<PlayerController>()
        //}
	}

}
