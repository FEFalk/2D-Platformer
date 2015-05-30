using UnityEngine;
using System.Collections;

public class ButtonHandler : MonoBehaviour {
    public GameObject Object;
    public GameObject Obstacle;
    public bool buttonActivate = false;
    public bool greenButtonActivate = false;
    private bool obstacle = false;
	// Update is called once per frame
	void Update () {

        if (buttonActivate && obstacle == false)
        {
            Obstacle.GetComponent<ObstacleHandler>().activated = true;
            buttonActivate = false;
            obstacle = true;
        }

        if (greenButtonActivate && Object!=null)
        {
            Object.GetComponent<UnityStandardAssets.CrossPlatformInput.PlayerController>().GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            Object.GetComponent<UnityStandardAssets.CrossPlatformInput.PlayerController>().currentMovement = 0;
            Object.GetComponent<UnityStandardAssets.CrossPlatformInput.PlayerController>().anim.SetFloat("Walking", Mathf.Abs(0));
            Object.GetComponent<UnityStandardAssets.CrossPlatformInput.PlayerController>().enabled = false;

            GetComponent<CircleCollider2D>().enabled = false;
            Camera.main.GetComponent<SmoothCamera2D>().target = transform;
            greenButtonActivate = false;
        }
        else if(greenButtonActivate)
        {
            Camera.main.GetComponent<SmoothCamera2D>().target = transform;
            greenButtonActivate = false;
        }
	}
}
