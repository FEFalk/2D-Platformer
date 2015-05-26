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
        if (greenButtonActivate)
        {
            Object.GetComponent<UnityStandardAssets.CrossPlatformInput.PlayerController>().GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            Object.GetComponent<UnityStandardAssets.CrossPlatformInput.PlayerController>().currentMovement = 0;
            Object.GetComponent<UnityStandardAssets.CrossPlatformInput.PlayerController>().anim.SetFloat("Walking", Mathf.Abs(0));
            Object.GetComponent<UnityStandardAssets.CrossPlatformInput.PlayerController>().enabled = false;

            //Camera.main.GetComponent<SmoothCamera2D>().target.transform.position = transform.position;
            greenButtonActivate = false;
        }
	}

}
